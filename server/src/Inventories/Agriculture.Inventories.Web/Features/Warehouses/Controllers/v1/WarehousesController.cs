using Agriculture.Inventories.Application.Features.Items.Commands.CreateItem;
using Agriculture.Inventories.Application.Features.Warehouses.Commands.CreateWarehouse;
using Agriculture.Inventories.Contracts.Features.Items.Commands.CreateItem;
using Agriculture.Inventories.Contracts.Features.Warehouses.Commands.CreateWarehouse;
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
    }
}
