namespace Agriculture.Transactions.Contracts.Features.BuyOrders.Queries.GetBuyOrders
{
    public class GetBuyOrdersQueryViewModel
    {
        public string Id { get; set; }
        public string SupplierName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
