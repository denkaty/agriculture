using Agriculture.Inventories.Application.Features.Inventories.Commands.Transfer;
using Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoriesByWarehouseId;
using Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoryByItemId;
using Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateBuyOrder;
using Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateSellOrder;
using Agriculture.Inventories.Contracts.Features.Inventories.Commands.Transfer;
using Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByItemId;
using Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByWarehouseId;
using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateBuyOrder;
using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Features.Transactions.Queries.ValidateBuyOrder;
using Agriculture.Shared.Web.Utilities;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Agriculture.Inventories.Web.Features.Inventories.Controllers.v1
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/inventories")]
    [EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
    public class InventoriesController : ControllerBase
    {
        private readonly IAgricultureMapper _agricultureMapper;
        private readonly IAgricultureSender _agricultureSender;

        public InventoriesController(IAgricultureMapper agricultureMapper, IAgricultureSender agricultureSender)
        {
            _agricultureMapper = agricultureMapper;
            _agricultureSender = agricultureSender;
        }

        [HttpGet("item/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByItemIdAsync(GetInventoriesByItemIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getInventoryByItemIdQuery = _agricultureMapper.Map<GetInventoriesByItemIdQuery>(request);

            var getInventoryByItemIdQueryResult = await _agricultureSender.SendAsync(getInventoryByItemIdQuery, cancellationToken);

            var getInventoryByItemIdQueryResponse = _agricultureMapper.Map<GetInventoriesByItemIdQueryResponse>(getInventoryByItemIdQueryResult);

            return Ok(getInventoryByItemIdQueryResponse);
        }

        [HttpGet("warehouse/{warehouseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByWarehouseIdAsync(GetInventoriesByWarehouseIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getInventoryByWarehouseIdQuery = _agricultureMapper.Map<GetInventoriesByWarehouseIdQuery>(request);

            var getInventoryByWarehouseIdQueryResult = await _agricultureSender.SendAsync(getInventoryByWarehouseIdQuery, cancellationToken);

            var getInventoryByWarehouseIdQueryResponse = _agricultureMapper.Map<GetInventoriesByWarehouseIdQueryResponse>(getInventoryByWarehouseIdQueryResult);

            return Ok(getInventoryByWarehouseIdQueryResponse);
        }

        [HttpPatch("transfers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> TransferAsync(TransferCommandRequest request, CancellationToken cancellationToken)
        {
            var transferCommand = _agricultureMapper.Map<TransferCommand>(request);

            await _agricultureSender.SendAsync(transferCommand, cancellationToken);

            return NoContent();
        }

        [HttpPost("validate-buy-order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidateAsync(ValidateBuyOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var validateBuyOrderQuery = _agricultureMapper.Map<ValidateBuyOrderQuery>(request);

            var validateBuyOrderResult = await _agricultureSender.SendAsync(validateBuyOrderQuery, cancellationToken);

            var validateBuyOrderResponse = _agricultureMapper.Map<ValidateBuyOrderQueryResponse>(validateBuyOrderResult);

            return Ok(validateBuyOrderResponse);
        }

        [HttpPost("validate-sell-order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidateAsync(ValidateSellOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var validateSellOrderQuery = _agricultureMapper.Map<ValidateSellOrderQuery>(request);

            var validateSellOrderResult = await _agricultureSender.SendAsync(validateSellOrderQuery, cancellationToken);

            var validateSellOrderResponse = _agricultureMapper.Map<ValidateSellOrderQueryResponse>(validateSellOrderResult);

            return Ok(validateSellOrderResponse);
        }

    }
}
