namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder
{
    public class InventorySellItemOrder
    {
        public string ItemId { get; set; }
        public string WarehouseId { get; set; }
        public int RequestedQuantity { get; set; }
    }
}
