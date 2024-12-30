using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateBuyOrder;

namespace Agriculture.Shared.Common.Features.Transactions.Queries.ValidateBuyOrder
{
    public class ValidateBuyOrderQueryBindingModel
    {
        public ValidateBuyOrderQueryBindingModel(ICollection<InventoryCompositeKey> compositeKeys)
        {
            CompositeKeys = compositeKeys;
        }

        public ICollection<InventoryCompositeKey> CompositeKeys { get; set; }
    }
}
