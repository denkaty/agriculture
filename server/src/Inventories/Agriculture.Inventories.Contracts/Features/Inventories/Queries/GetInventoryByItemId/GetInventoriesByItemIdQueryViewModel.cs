namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByItemId
{
    public class GetInventoriesByItemIdQueryViewModel
    {
        public string ItemId { get; set; }
        public string WarehouseId { get; set; }
        public int Quantity { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
