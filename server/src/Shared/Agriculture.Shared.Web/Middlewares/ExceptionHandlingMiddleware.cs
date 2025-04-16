using Agriculture.Shared.Common.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Agriculture.Shared.Common.Models.Enums;

namespace Agriculture.Shared.Web.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "An unhandled exception occurred.");
                await TryHandleAsync(httpContext, exception, CancellationToken.None);
            }
        }

        private async Task TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if(exception is ValidationException validationException)
            {
                await HandleValidationExceptionAsync(httpContext, validationException, cancellationToken);
            }
            else if (exception is BaseException baseException)
            {
                await HandleBaseExceptionAsync(httpContext, baseException, cancellationToken);
            }
            else
            {
                await HandleExceptionAsync(httpContext, exception, cancellationToken);
            }
        }

        private async Task HandleValidationExceptionAsync(HttpContext httpContext, ValidationException validationException, CancellationToken cancellationToken)
        {
            var statusCode = (int)validationException.StatusCode;

            httpContext.Response.ContentType = "application/json";

            var validationProblemDetails = new ValidationProblemDetails()
            {
                Type = validationException.GetType().Name,
                Title = Enum.GetName(validationException.StatusCode),
                Status = statusCode,
                Detail = validationException.Message,
                Errors = validationException.Errors
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(validationProblemDetails, cancellationToken);
        }

        private async Task HandleBaseExceptionAsync(HttpContext httpContext, BaseException baseException, CancellationToken cancellationToken)
        {
            var statusCode = (int)baseException.StatusCode;

            httpContext.Response.ContentType = "application/json";

            var validationProblemDetails = new ValidationProblemDetails()
            {
                Type = baseException.GetType().Name,
                Title = Enum.GetName(baseException.StatusCode),
                Status = statusCode,
                Detail = baseException.Message
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(validationProblemDetails, cancellationToken);
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            var validationProblemDetails = new ValidationProblemDetails()
            {
                Type = "UnhandledException",
                Title = "Unhandled exception",
                Status = (int) AgricultureStatusCode.InternalServerError,
                Detail = exception.InnerException?.Message ?? exception.Message
            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(validationProblemDetails, cancellationToken);
        }
    }
}
