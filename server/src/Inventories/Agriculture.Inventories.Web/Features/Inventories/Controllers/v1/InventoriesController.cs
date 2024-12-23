using Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoriesByWarehouseId;
using Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoryByItemId;
using Agriculture.Inventories.Application.Features.Warehouses.Queries.GetWarehouses;
using Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByItemId;
using Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByWarehouseId;
using Agriculture.Inventories.Contracts.Features.Warehouses.Queries.GetInventories;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
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

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetAllAsync(GetInventoriesQueryRequest request, CancellationToken cancellationToken)
        //{
        //    var getInventoriesQuery = _agricultureMapper.Map<GetInventoriesQuery>(request);

        //    var getInventoriesQueryResult = await _agricultureSender.SendAsync(getInventoriesQuery, cancellationToken);

        //    var getInventoriesQueryResponse = _agricultureMapper.Map<GetInventoriesQueryResponse>(getInventoriesQueryResult);

        //    return Ok(getInventoriesQueryResponse);
        //}

        [HttpGet("item/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByItemIdAsync(GetInventoriesByItemIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getInventoryByItemId = _agricultureMapper.Map<GetInventoriesByItemIdQuery>(request);

            var getInventoryByItemIdQueryResult = await _agricultureSender.SendAsync(getInventoryByItemId, cancellationToken);

            var getInventoryByItemIdQueryResponse = _agricultureMapper.Map<GetInventoriesByItemIdQueryResponse>(getInventoryByItemIdQueryResult);

            return Ok(getInventoryByItemIdQueryResponse);
        }

        [HttpGet("warehouse/{warehouseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByWarehouseIdAsync(GetInventoriesByWarehouseIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getInventoryByWarehouseId = _agricultureMapper.Map<GetInventoriesByWarehouseIdQuery>(request);

            var getInventoryByWarehouseIdQueryResult = await _agricultureSender.SendAsync(getInventoryByWarehouseId, cancellationToken);

            var getInventoryByWarehouseIdQueryResponse = _agricultureMapper.Map<GetInventoriesByWarehouseIdQueryResponse>(getInventoryByWarehouseIdQueryResult);

            return Ok(getInventoryByWarehouseIdQueryResponse);
        }
       
    }
}
