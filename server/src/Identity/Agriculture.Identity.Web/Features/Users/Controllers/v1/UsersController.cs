using Agriculture.Identity.Application.Features.Users.Commands.Register;
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
        private readonly IAgricultureSender _sender;
        private readonly IAgricultureMapper _mapper;
        private readonly ICurrentUserContext _currentUserContext;

        public UsersController(IAgricultureSender sender, IAgricultureMapper mapper, ICurrentUserContext currentUserContext)
        {
            _sender = sender;
            _mapper = mapper;
            _currentUserContext = currentUserContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            RegisterCommand registerCommand = _mapper.Map<RegisterCommand>(request);
            RegisterCommandResult registerCommandResult = await _sender.SendAsync(registerCommand, cancellationToken);
            RegisterCommandResponse registerCommandRespone = _mapper.Map<RegisterCommandResponse>(registerCommandResult);
            return Ok(registerCommandRespone);
        }

        [HttpGet("login")]
        public async Task<IActionResult> Test(CancellationToken cancellationToken)
        {
            return Ok("bravo");
        }
    }
}
