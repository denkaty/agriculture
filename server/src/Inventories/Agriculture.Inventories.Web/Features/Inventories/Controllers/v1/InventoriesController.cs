using Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoryByItemId;
using Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByItemId;
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


        [HttpGet("item/{itemId}")]
        public async Task<IActionResult> GetByItemIdAsync(GetInventoriesByItemIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getInventoryByItemId = _agricultureMapper.Map<GetInventoriesByItemIdQuery>(request);

            var getInventoryByItemIdQueryResult = await _agricultureSender.SendAsync(getInventoryByItemId, cancellationToken);

            var getInventoryByItemIdQueryResponse = _agricultureMapper.Map<GetInventoriesByItemIdQueryResponse>(getInventoryByItemIdQueryResult);

            return Ok(getInventoryByItemIdQueryResponse);
        }

        //[HttpGet("warehouse/{warehouseId}")]
        //public async Task<IActionResult> GetInventoryByWarehouse(GetInventoryByWarehouseIdQueryRequest warehouseId, CancellationToken cancellationToken)
        //{
        //    var getInventoryByWarehouseId = _agricultureMapper.Map<GetInventoryByWarehouseIdQuery>(request);

        //    var getInventoryByWarehouseIdResult = await _agricultureSender.SendAsync(getInventoryByWarehouseId, cancellationToken);

        //    var getInventoryByWarehouseIdResponse = _agricultureMapper.Map<GetInventoryByWarehouseIdQueryResponse>(getInventoryByWarehouseIdResult);

        //    return Ok(getInventoryByWarehouseIdResponse);
        //}
    }
}
