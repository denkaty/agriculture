using Agriculture.Identity.Application.Features.Users.Commands.ChangePassword;
using Agriculture.Identity.Application.Features.Users.Commands.Register;
using Agriculture.Identity.Application.Features.Users.Commands.RequestResetPassword;
using Agriculture.Identity.Application.Features.Users.Commands.ResetPassword;
using Agriculture.Identity.Application.Features.Users.Queries.GetUsers;
using Agriculture.Identity.Application.Features.Users.Queries.Login;
using Agriculture.Identity.Contracts.Features.Users.ChangePassword;
using Agriculture.Identity.Contracts.Features.Users.GetUsers;
using Agriculture.Identity.Contracts.Features.Users.Login;
using Agriculture.Identity.Contracts.Features.Users.Register;
using Agriculture.Identity.Contracts.Features.Users.RequestResetPassword;
using Agriculture.Identity.Contracts.Features.Users.ResetPassword;
using Agriculture.Identity.Web.Features.Users.Models.Requests;
using Agriculture.Shared.Application.Abstractions.CurrentUserContext;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Web.Utilities;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var registerCommand = _agricultureMapper.Map<RegisterCommand>(request);

            var registerCommandResult = await _agricultureSender.SendAsync(registerCommand, cancellationToken);

            var registerCommandResponse = _agricultureMapper.Map<RegisterCommandResponse>(registerCommandResult);

            return Ok(registerCommandResponse);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            var loginQuery = _agricultureMapper.Map<LoginQuery>(request);

            var loginQueryResult = await _agricultureSender.SendAsync(loginQuery, cancellationToken);

            var loginQueryResponse = _agricultureMapper.Map<LoginQueryResponse>(loginQueryResult);

            return Ok(loginQueryResponse);
        }

        [HttpPost("request-reset-password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePasswordAsync(RequestResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var resetPasswordCommand = _agricultureMapper.Map<RequestResetPasswordCommand>(request);

            await _agricultureSender.SendAsync(resetPasswordCommand, cancellationToken);

            return NoContent();
        }

        [HttpPatch("reset-password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePasswordAsync(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var changePasswordCommand = _agricultureMapper.Map<ResetPasswordCommand>(request);

            await _agricultureSender.SendAsync(changePasswordCommand, cancellationToken);

            return NoContent();
        }

        [HttpPatch("me/password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            string currentUserId = _currentUserContext.GetCurrentUserId();

            var changePasswordCommand = _agricultureMapper.Map<ChangePasswordCommand>((request, currentUserId));

            await _agricultureSender.SendAsync(changePasswordCommand, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = _agricultureMapper.Map<GetUsersQuery>(request);

            var result = await _agricultureSender.SendAsync(query, cancellationToken);

            var response = _agricultureMapper.Map<GetUsersResponse>(result);

            return Ok(response);
        }


    }
}
