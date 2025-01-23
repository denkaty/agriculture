namespace Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateBuyOrder
{
    public class ValidateBuyOrderQueryRequest
    {
        public ICollection<InventoryCompositeKey> CompositeKeys { get; set; }
    }
}
