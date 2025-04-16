namespace Agriculture.Transactions.Contracts.Features.BuyOrders.Queries.GetBuyOrderById
{
    public class GetBuyOrderByIdQueryResponse
    {
        public string Id { get; set; }
        public string SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<BuyOrderItemViewModel> Items { get; set; } = new();
    }
}
