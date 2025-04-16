namespace Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateBuyOrder
{
    public class InventoryCompositeKey
    {
        public string ItemId { get; set; }
        public string WarehouseId { get; set; }
    }
}
