namespace Agriculture.Transactions.Contracts.Features.BuyOrders.Queries.GetBuyOrders
{
    public class GetBuyOrdersQueryResponse
    {
        public IReadOnlyCollection<GetBuyOrdersQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
