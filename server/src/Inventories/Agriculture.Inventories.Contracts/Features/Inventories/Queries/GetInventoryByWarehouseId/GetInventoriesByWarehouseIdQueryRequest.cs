using Agriculture.Shared.Application.Models.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByWarehouseId
{
    public class GetInventoriesByWarehouseIdQueryRequest : PaginatedSortedRequest
    {
        [FromRoute(Name = "warehouseId")]
        public string WarehouseId { get; set; } = string.Empty;
    }
}
