using Agriculture.Identity.Application.Features.Users.Commands.ChangePassword;
using Agriculture.Identity.Application.Features.Users.Commands.Register;
using Agriculture.Identity.Application.Features.Users.Commands.RequestResetPassword;
using Agriculture.Identity.Application.Features.Users.Commands.ResetPassword;
using Agriculture.Identity.Application.Features.Users.Queries.GetUserById;
using Agriculture.Identity.Application.Features.Users.Queries.GetUsers;
using Agriculture.Identity.Application.Features.Users.Queries.Login;
using Agriculture.Identity.Contracts.Features.Users.Commands.ChangePassword;
using Agriculture.Identity.Contracts.Features.Users.Commands.Register;
using Agriculture.Identity.Contracts.Features.Users.Commands.RequestResetPassword;
using Agriculture.Identity.Contracts.Features.Users.Commands.ResetPassword;
using Agriculture.Identity.Contracts.Features.Users.Queries.GetUserById;
using Agriculture.Identity.Contracts.Features.Users.Queries.GetUsers;
using Agriculture.Identity.Contracts.Features.Users.Queries.Login;
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

        public UsersController(
            IAgricultureMapper agricultureMapper,
            IAgricultureSender agricultureSender)
        {
            _agricultureMapper = agricultureMapper;
            _agricultureSender = agricultureSender;
        }

        [HttpPost("register")]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        public async Task<IActionResult> RequestResetPasswordAsync(RequestResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var requestResetPasswordCommand = _agricultureMapper.Map<RequestResetPasswordCommand>(request);

            await _agricultureSender.SendAsync(requestResetPasswordCommand, cancellationToken);

            return NoContent();
        }

        [HttpPatch("reset-password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var resetPasswordCommand = _agricultureMapper.Map<ResetPasswordCommand>(request);

            await _agricultureSender.SendAsync(resetPasswordCommand, cancellationToken);

            return NoContent();
        }

        [HttpPatch("me/password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var changePasswordCommand = _agricultureMapper.Map<ChangePasswordCommand>(request);

            await _agricultureSender.SendAsync(changePasswordCommand, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsersAsync(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var getUsersQuery = _agricultureMapper.Map<GetUsersQuery>(request);

            var getUsersQueryResult = await _agricultureSender.SendAsync(getUsersQuery, cancellationToken);

            var getUsersQueryResponse = _agricultureMapper.Map<GetUsersQueryResponse>(getUsersQueryResult);

            return Ok(getUsersQueryResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByIdAsync(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getUserByIdQuery = _agricultureMapper.Map<GetUserByIdQuery>(request);

            var getUserByIdQueryResult = await _agricultureSender.SendAsync(getUserByIdQuery, cancellationToken);

            var getUserByIdQueryResponse = _agricultureMapper.Map<GetUserByIdQueryResponse>(getUserByIdQueryResult);

            return Ok(getUserByIdQueryResponse);
        }

    }
}
