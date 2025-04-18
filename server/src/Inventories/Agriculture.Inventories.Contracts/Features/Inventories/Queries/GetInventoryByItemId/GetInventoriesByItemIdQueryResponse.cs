﻿using Agriculture.Inventories.Contracts.Features.Items.Quries.GetItems;
namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByItemId
{
    public class GetInventoriesByItemIdQueryResponse
    {
        public IReadOnlyCollection<GetInventoriesByItemIdQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
