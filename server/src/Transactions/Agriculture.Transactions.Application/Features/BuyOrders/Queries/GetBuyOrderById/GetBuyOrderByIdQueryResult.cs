using Agriculture.Transactions.Contracts.Features.BuyOrders.Queries.GetBuyOrderById;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Queries.GetBuyOrderById
{
    public class GetBuyOrderByIdQueryResult
    {
        public string Id { get; set; }
        public string SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<BuyOrderItemViewModel> Items { get; set; } = new();
    }
}
