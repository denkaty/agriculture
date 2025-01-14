using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateBuyOrder;

namespace Agriculture.Shared.Common.Features.Transactions.Queries.ValidateBuyOrder
{
    public class ValidateBuyOrderQueryBindingModel
    {
        public ValidateBuyOrderQueryBindingModel(ICollection<InventoryBuyItemOrder> inventoryBuyItemOrders)
        {
            InventoryBuyItemOrders = inventoryBuyItemOrders;
        }

        public ICollection<InventoryBuyItemOrder> InventoryBuyItemOrders { get; set; }
    }
}
