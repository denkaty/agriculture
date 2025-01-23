namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder
{
    public class ValidateSellOrderQueryResponse
    {
        public bool IsValid { get; set; }
        public ICollection<NotFoundCompositeKeyInventory> NotFoundCompositeKeyInventories { get; set; }
        public ICollection<InsufficientQuantityInventory> InsufficientQuantityInventories { get; set; }
    }

    public class InventoryCompositeKey
    {
        public string ItemId { get; set; }
        public string WarehouseId { get; set; }
    }

    public class NotFoundCompositeKeyInventory
    {
        public InventoryCompositeKey CompositeKey { get; set; }

    }

    public class InsufficientQuantityInventory
    {
        public InventoryCompositeKey CompositeKey { get; set; }
        public int AvailableQuantity { get; set; }
        public int RequestedQuantity { get; set; }
    }

}
