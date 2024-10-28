using Agriculture.Identity.Application.Features.Users.Commands.Register;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Domain.Abstractions;
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

        [HttpPost]
        public async Task<IActionResult> Test([FromQuery] string email, CancellationToken cancellationToken)
        {
            RegisterCommand registerCommand = new RegisterCommand(email);
            await _sender.SendAsync(registerCommand, cancellationToken);
            return Ok("v1");
        }
    }
}
