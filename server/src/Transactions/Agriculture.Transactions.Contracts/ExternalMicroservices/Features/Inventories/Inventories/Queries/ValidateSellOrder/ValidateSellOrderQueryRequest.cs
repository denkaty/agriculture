namespace Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateSellOrder
{
    public class ValidateSellOrderQueryRequest
    {
        public ICollection<InventorySellItemOrder> InventorySellItemOrders { get; set; }
    }
}
