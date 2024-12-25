using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Inventories.Contracts.Features.Warehouses.Queries.GetWarehouseById
{
    public class GetWarehouseByIdQueryRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
