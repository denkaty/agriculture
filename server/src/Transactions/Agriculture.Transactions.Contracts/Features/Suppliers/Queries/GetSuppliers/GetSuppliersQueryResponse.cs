namespace Agriculture.Transactions.Contracts.Features.Suppliers.Queries.GetSuppliers
{
    public class GetSuppliersQueryResponse
    {
        public IReadOnlyCollection<GetSuppliersQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
