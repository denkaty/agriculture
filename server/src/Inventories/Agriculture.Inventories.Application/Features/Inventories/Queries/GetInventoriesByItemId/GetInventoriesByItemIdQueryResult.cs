using Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByItemId;
namespace Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoryByItemId
{
    public class GetInventoriesByItemIdQueryResult
    {
        public IReadOnlyCollection<GetInventoriesByItemIdQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;
    }
}
