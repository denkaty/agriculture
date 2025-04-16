using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateBuyOrder;

namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder
{
    public class ValidateSellOrderQueryBindingModel
    {
        public ValidateSellOrderQueryBindingModel(ICollection<InventorySellItemOrder> inventorySellItemOrders)
        {
            InventorySellItemOrders = inventorySellItemOrders;
        }

        public ICollection<InventorySellItemOrder> InventorySellItemOrders { get; set; }
    }
}
