
namespace Agriculture.Inventories.Contracts.Features.Warehouses.Queries.GetInventories
{
    public class GetWarehousesQueryResponse
    {
        public IReadOnlyCollection<GetWarehousesQueryViewModel> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
