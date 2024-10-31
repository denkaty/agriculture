using Agriculture.Identity.Application.Features.Users.Commands.Register;
using Agriculture.Identity.Contracts.Features.Users.Register;
using Agriculture.Identity.Web.Features.Users.Models.Requests;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Web.Features.Users.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAgricultureSender _sender;
        private readonly IAgricultureMapper _mapper;

        public UsersController(IAgricultureSender sender, IAgricultureMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            RegisterCommand registerCommand = _mapper.Map<RegisterCommand>(request);
            RegisterCommandResult registerCommandResult = await _sender.SendAsync(registerCommand, cancellationToken);
            RegisterCommandResponse registerCommandRespone = _mapper.Map<RegisterCommandResponse>(registerCommandResult);
            return Ok(registerCommandRespone);
        }
    }
}
