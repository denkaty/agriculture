using Agriculture.Identity.Application.Features.Users.Commands.ChangePassword;
using Agriculture.Identity.Application.Features.Users.Commands.Register;
using Agriculture.Identity.Application.Features.Users.Commands.RequestResetPassword;
using Agriculture.Identity.Application.Features.Users.Queries.Login;
using Agriculture.Identity.Contracts.Features.Users.ChangePassword;
using Agriculture.Identity.Contracts.Features.Users.Login;
using Agriculture.Identity.Contracts.Features.Users.Register;
using Agriculture.Identity.Contracts.Features.Users.ResetPassword;
using Agriculture.Identity.Web.Features.Users.Models.Requests;
using Agriculture.Shared.Application.Abstractions.CurrentUserContext;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Web.Utilities;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Agriculture.Identity.Web.Features.Users.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/users")]
    [EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
    public class UsersController : ControllerBase
    {
        private readonly IAgricultureMapper _agricultureMapper;
        private readonly IAgricultureSender _agricultureSender;
        private readonly ICurrentUserContext _currentUserContext;

        public UsersController(
            IAgricultureMapper agricultureMapper,
            IAgricultureSender agricultureSender,
            ICurrentUserContext currentUserContext)
        {
            _agricultureMapper = agricultureMapper;
            _agricultureSender = agricultureSender;
            _currentUserContext = currentUserContext;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var registerCommand = _agricultureMapper.Map<RegisterCommand>(request);

            var registerCommandResult = await _agricultureSender.SendAsync(registerCommand, cancellationToken);

            var registerCommandResponse = _agricultureMapper.Map<RegisterCommandResponse>(registerCommandResult);

            return Ok(registerCommandResponse);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginQueryRequest request, CancellationToken cancellationToken)
        {
            var loginQuery = _agricultureMapper.Map<LoginQuery>(request);

            var loginQueryResult = await _agricultureSender.SendAsync(loginQuery, cancellationToken);

            var loginQueryResponse = _agricultureMapper.Map<LoginQueryResponse>(loginQueryResult);

            return Ok(loginQueryResponse);
        }

        [HttpPost("request-reset-password")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] RequestResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var resetPasswordCommand = _agricultureMapper.Map<RequestResetPasswordCommand>(request);

            await _agricultureSender.SendAsync(resetPasswordCommand, cancellationToken);

            return NoContent();
        }

        [HttpPatch("change-password")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var changePasswordCommand = _agricultureMapper.Map<ChangePasswordCommand>(request);

            await _agricultureSender.SendAsync(changePasswordCommand, cancellationToken);

            return NoContent();
        }
    }
}
