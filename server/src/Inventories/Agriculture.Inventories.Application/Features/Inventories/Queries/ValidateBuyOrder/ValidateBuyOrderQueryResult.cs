namespace Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateBuyOrder
{
    public class ValidateBuyOrderQueryResult
    {
        public bool IsValid { get; set; }
        public ICollection<(string ItemId, string WarehouseId)> InvalidInventoryBuyItemOrders { get; set; }
    }
}
