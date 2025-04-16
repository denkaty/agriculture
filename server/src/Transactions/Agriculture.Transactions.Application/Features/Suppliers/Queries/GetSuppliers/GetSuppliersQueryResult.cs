using Agriculture.Transactions.Contracts.Features.Suppliers.Queries.GetSuppliers;

namespace Agriculture.Transactions.Application.Features.Suppliers.Queries.GetSuppliers
{
    public class GetSuppliersQueryResult
    {
        public IReadOnlyCollection<GetSuppliersQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;
    }
}
