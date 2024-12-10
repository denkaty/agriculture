using Agriculture.Inventories.Contracts.Features.Warehouses.Queries.GetInventories;

namespace Agriculture.Inventories.Application.Features.Warehouses.Queries.GetWarehouses
{
    public class GetWarehousesQueryResult
    {
        public IReadOnlyCollection<GetWarehousesQueryViewModel> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;
    }
}
