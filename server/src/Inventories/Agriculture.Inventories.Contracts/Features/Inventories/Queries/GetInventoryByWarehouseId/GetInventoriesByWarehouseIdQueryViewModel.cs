namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByWarehouseId
{
    public class GetInventoriesByWarehouseIdQueryViewModel
    {
        public string Id { get; set; }
        public string ItemId { get; set; }
        public string WarehouseId { get; set; }
        public int Quantity { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
