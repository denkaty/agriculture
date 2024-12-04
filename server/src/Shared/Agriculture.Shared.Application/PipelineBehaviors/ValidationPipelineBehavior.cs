using FluentValidation;
using MediatR;
using ValidationException = Agriculture.Shared.Common.Exceptions.Base.ValidationException;

namespace Agriculture.Shared.Application.PipelineBehaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var validationContext = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(validationContext)));


            var validationFailures = validationResults
                .Where(vr => !vr.IsValid)
                .SelectMany(vr => vr.Errors)
                .GroupBy(
                failure => failure.PropertyName,
                failure => failure.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    PropertyName = propertyName,
                    ErrorMessages = errorMessages.ToArray()
                })
                .ToDictionary(
                item => item.PropertyName,
                item => item.ErrorMessages);

            if (validationFailures.Any())
            {
                throw new ValidationException(validationFailures);
            }

            return await next();
        }
    }
}
