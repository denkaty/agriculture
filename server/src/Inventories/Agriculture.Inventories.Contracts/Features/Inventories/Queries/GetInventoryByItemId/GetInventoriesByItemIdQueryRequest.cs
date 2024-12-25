using Agriculture.Shared.Application.Models.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByItemId
{
    public class GetInventoriesByItemIdQueryRequest : PaginatedSortedRequest
    {
        [FromRoute(Name = "itemId")]
        public string ItemId { get; set; } = string.Empty;
    }
}
