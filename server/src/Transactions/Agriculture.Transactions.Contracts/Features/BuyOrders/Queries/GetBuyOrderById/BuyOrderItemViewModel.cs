namespace Agriculture.Transactions.Contracts.Features.BuyOrders.Queries.GetBuyOrderById
{
    public class BuyOrderItemViewModel
    {
        public string ItemId { get; set; }
        public string WarehouseId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
