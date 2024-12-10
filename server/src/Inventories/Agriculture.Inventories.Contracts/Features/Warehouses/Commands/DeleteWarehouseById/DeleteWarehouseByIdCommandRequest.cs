using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Inventories.Contracts.Features.Warehouses.Commands.DeleteWarehouseById
{
    public class DeleteWarehouseByIdCommandRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
