using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Inventories.Inventories
{
    public class InventoryEmptyCollectionException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "No inventories were found";

        public InventoryEmptyCollectionException() : base(ERROR_MESSAGE_TEMPLATE)
        {
        }
    }
}
