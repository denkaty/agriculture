namespace Agriculture.Transactions.Contracts.Features.SellOrders.Commands.CreateSellOrder
{
    public class CreateSellOrderItemBindingModel
    {
        public CreateSellOrderItemBindingModel(string itemId, string warehouseId, int requestedQuantity, decimal unitPrice)
        {
            ItemId = itemId;
            WarehouseId = warehouseId;
            RequestedQuantity = requestedQuantity;
            UnitPrice = unitPrice;
        }

        public string ItemId { get; set; } = string.Empty;
        public string WarehouseId { get; set; } = string.Empty;
        public int RequestedQuantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
