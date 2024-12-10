using Agriculture.Inventories.Application.Features.Items.Commands.CreateItem;
using Agriculture.Inventories.Application.Features.Items.Commands.DeleteItemById;
using Agriculture.Inventories.Application.Features.Items.Queries.GetItemById;
using Agriculture.Inventories.Application.Features.Items.Queries.GetItems;
using Agriculture.Inventories.Application.Features.Warehouses.Commands.CreateWarehouse;
using Agriculture.Inventories.Application.Features.Warehouses.Commands.DeleteWarehouseById;
using Agriculture.Inventories.Application.Features.Warehouses.Queries.GetWarehouseById;
using Agriculture.Inventories.Application.Features.Warehouses.Queries.GetWarehouses;
using Agriculture.Inventories.Contracts.Features.Items.Commands.CreateItem;
using Agriculture.Inventories.Contracts.Features.Items.Commands.DeleteItemById;
using Agriculture.Inventories.Contracts.Features.Items.Quries.GetItemById;
using Agriculture.Inventories.Contracts.Features.Items.Quries.GetItems;
using Agriculture.Inventories.Contracts.Features.Warehouses.Commands.CreateWarehouse;
using Agriculture.Inventories.Contracts.Features.Warehouses.Commands.DeleteWarehouseById;
using Agriculture.Inventories.Contracts.Features.Warehouses.Queries.GetInventories;
using Agriculture.Inventories.Contracts.Features.Warehouses.Queries.GetWarehouseById;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Web.Utilities;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Agriculture.Inventories.Web.Features.Warehouses.Controllers.v1
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/warehouses")]
    [EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
    public class WarehousesController : ControllerBase
    {
        private readonly IAgricultureMapper _agricultureMapper;
        private readonly IAgricultureSender _agricultureSender;

        public WarehousesController(
            IAgricultureMapper agricultureMapper,
            IAgricultureSender agricultureSender)
        {
            _agricultureMapper = agricultureMapper;
            _agricultureSender = agricultureSender;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateWarehouseCommandRequest request, CancellationToken cancellationToken)
        {
            var createWarehouseCommand = _agricultureMapper.Map<CreateWarehouseCommand>(request);

            var createWarehouseCommandResult = await _agricultureSender.SendAsync(createWarehouseCommand, cancellationToken);

            var createWarehouseCommandResponse = _agricultureMapper.Map<CreateWarehouseCommandResponse>(createWarehouseCommandResult);

            return Ok(createWarehouseCommandResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(GetWarehousesQueryRequest request, CancellationToken cancellationToken)
        {
            var getWarehousesQuery = _agricultureMapper.Map<GetWarehousesQuery>(request);

            var getWarehousesQueryResult = await _agricultureSender.SendAsync(getWarehousesQuery, cancellationToken);

            var getWarehousesQueryResponse = _agricultureMapper.Map<GetWarehousesQueryResponse>(getWarehousesQueryResult);

            return Ok(getWarehousesQueryResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetWarehouseByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getWarehouseByIdQuery = _agricultureMapper.Map<GetWarehouseByIdQuery>(request);

            var getWarehouseByIdQueryResult = await _agricultureSender.SendAsync(getWarehouseByIdQuery, cancellationToken);

            var getWarehouseByIdQueryResponse = _agricultureMapper.Map<GetWarehouseByIdQueryResponse>(getWarehouseByIdQueryResult);

            return Ok(getWarehouseByIdQueryResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync(DeleteWarehouseByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteWarehouseByIdCommand = _agricultureMapper.Map<DeleteWarehouseByIdCommand>(request);

            await _agricultureSender.SendAsync(deleteWarehouseByIdCommand, cancellationToken);

            return NoContent();
        }
    }
}
