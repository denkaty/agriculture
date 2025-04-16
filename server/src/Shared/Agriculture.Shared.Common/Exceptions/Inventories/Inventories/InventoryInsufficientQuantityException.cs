namespace Agriculture.Shared.Common.Exceptions.Inventories.Inventories
{
    public class InventoryInsufficientQuantityException : BadImageFormatException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Not enough quantity for Item ID '{item.ItemId}'. Requested: {item.Quantity}, Available: {inventory.Quantity}";

        public InventoryInsufficientQuantityException(string itemId, int requestedQuantity, int availableQuantity)
            : base(string.Format(ERROR_MESSAGE_TEMPLATE, itemId, requestedQuantity, availableQuantity))
        {
        }
    }
}
