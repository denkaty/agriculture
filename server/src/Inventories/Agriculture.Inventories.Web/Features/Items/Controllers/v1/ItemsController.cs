using Agriculture.Inventories.Application.Features.Items.Commands.CreateItem;
using Agriculture.Inventories.Application.Features.Items.Commands.DeleteItemById;
using Agriculture.Inventories.Application.Features.Items.Queries.GetItemById;
using Agriculture.Inventories.Application.Features.Items.Queries.GetItems;
using Agriculture.Inventories.Contracts.Features.Items.Commands.CreateItem;
using Agriculture.Inventories.Contracts.Features.Items.Commands.DeleteItemById;
using Agriculture.Inventories.Contracts.Features.Items.Quries.GetItemById;
using Agriculture.Inventories.Contracts.Features.Items.Quries.GetItems;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Web.Utilities;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Agriculture.Inventories.Web.Features.Items.Controllers.v1
{
    [AllowAnonymous]
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
        public async Task<IActionResult> CreateAsync(CreateItemCommandRequest request, CancellationToken cancellationToken)
        {
            var createItemCommand = _agricultureMapper.Map<CreateItemCommand>(request);

            var createItemCommandResult = await _agricultureSender.SendAsync(createItemCommand, cancellationToken);

            var createItemCommandResponse = _agricultureMapper.Map<CreateItemCommandResponse>(createItemCommandResult);

            return Ok(createItemCommandResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetItemByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getItemByIdQuery = _agricultureMapper.Map<GetItemByIdQuery>(request);

            var getItemByIdQueryResult = await _agricultureSender.SendAsync(getItemByIdQuery, cancellationToken);

            var getItemByIdQueryResponse = _agricultureMapper.Map<GetItemByIdQueryResponse>(getItemByIdQueryResult);

            return Ok(getItemByIdQueryResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(GetItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var getItemsQuery = _agricultureMapper.Map<GetItemsQuery>(request);

            var getItemsQueryResult = await _agricultureSender.SendAsync(getItemsQuery, cancellationToken);

            var getItemsQueryResponse = _agricultureMapper.Map<GetItemsQueryResponse>(getItemsQueryResult);

            return Ok(getItemsQueryResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync(DeleteItemByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteItemByIdCommand = _agricultureMapper.Map<DeleteItemByIdCommand>(request);

            await _agricultureSender.SendAsync(deleteItemByIdCommand, cancellationToken);

            return NoContent();
        }


    }
}
