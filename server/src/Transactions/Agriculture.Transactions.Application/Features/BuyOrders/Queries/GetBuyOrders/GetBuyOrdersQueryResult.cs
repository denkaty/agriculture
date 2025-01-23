using Agriculture.Transactions.Contracts.Features.BuyOrders.Queries.GetBuyOrders;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Queries.GetBuyOrders
{
    public class GetBuyOrdersQueryResult
    {
        public IReadOnlyCollection<GetBuyOrdersQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;
    }
}
