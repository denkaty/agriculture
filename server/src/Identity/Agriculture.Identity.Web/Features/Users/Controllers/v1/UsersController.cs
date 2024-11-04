using Agriculture.Identity.Application.Features.Users.Commands.Register;
using Agriculture.Identity.Application.Features.Users.Queries.Login;
using Agriculture.Identity.Contracts.Features.Users.Register;
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
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            RegisterCommand registerCommand = _agricultureMapper.Map<RegisterCommand>(request);
            RegisterCommandResult registerCommandResult = await _agricultureSender.SendAsync(registerCommand, cancellationToken);
            RegisterCommandResponse registerCommandResponse = _agricultureMapper.Map<RegisterCommandResponse>(registerCommandResult);
            return Ok(registerCommandResponse);
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginAsync([FromQuery]string Email, CancellationToken cancellationToken)
        {
            LoginQuery loginQuery = new LoginQuery(Email);
            LoginQueryResult loginQueryResult = await _agricultureSender.SendAsync(loginQuery,cancellationToken);

            return Ok(loginQueryResult);
        }
    }
}
