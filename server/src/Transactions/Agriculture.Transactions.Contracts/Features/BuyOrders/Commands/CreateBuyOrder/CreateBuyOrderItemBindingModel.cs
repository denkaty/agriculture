namespace Agriculture.Transactions.Contracts.Features.BuyOrders.Commands.CreateBuyOrder
{
    public class CreateBuyOrderItemBindingModel
    {
        public CreateBuyOrderItemBindingModel(string itemId, string warehouseId, int quantity, decimal unitPrice)
        {
            ItemId = itemId;
            WarehouseId = warehouseId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
        public string ItemId { get; set; } = string.Empty;
        public string WarehouseId { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
