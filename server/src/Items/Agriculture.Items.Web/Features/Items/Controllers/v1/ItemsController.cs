using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Web.Utilities;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Agriculture.Items.Web.Features.Items.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/items")]
    [EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
    public class ItemsController : ControllerBase
    {
        private readonly IAgricultureMapper _agricultureMapper;
        private readonly IAgricultureSender _agricultureSender;

        public ItemsController(
            IAgricultureMapper agricultureMapper,
            IAgricultureSender agricultureSender)
        {
            _agricultureMapper = agricultureMapper;
            _agricultureSender = agricultureSender;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(/*CreateItemCommandRequest request, CancellationToken cancellationToken*/)
        {
            //var createItemCommand = _agricultureMapper.Map<CreateItemCommand>(request);

            //var createItemCommandResult = await _agricultureSender.SendAsync(createItemCommand, cancellationToken);

            //var createItemCommandResponse = _agricultureMapper.Map<CreateItemCommandResponse>(createItemCommandResult);

            return Ok(/*createItemCommandResponse*/);
        }
    }
}
