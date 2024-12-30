namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateBuyOrder
{
    public class ValidateBuyOrderQueryResponse
    {
        public bool IsValid { get; set; }
        public ICollection<InventoryCompositeKey> InvalidCompositeKeys { get; set; }
    }
}
