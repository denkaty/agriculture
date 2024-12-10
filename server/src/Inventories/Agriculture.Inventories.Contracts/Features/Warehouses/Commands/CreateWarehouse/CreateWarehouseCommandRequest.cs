using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Inventories.Contracts.Features.Warehouses.Commands.CreateWarehouse
{
    public class CreateWarehouseCommandRequest
    {
        [FromBody]
        public CreateWarehouseCommandBindingModel CreateWarehouseCommandBindingModel { get; set; } = new(string.Empty, string.Empty);
    }
}
