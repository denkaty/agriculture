using Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByWarehouseId;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoriesByWarehouseId
{
    public class GetInventoriesByWarehouseIdQueryResult
    {
        public IReadOnlyCollection<GetInventoriesByWarehouseIdQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;
    }
}
