using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Inventories.Inventories
{
    public class InventoryItemNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Item with ID '{item.ItemId}' is not available in the warehouse.";

        public InventoryItemNotFoundException(string itemIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, itemIdentifier))
        {
        }
    }
}
