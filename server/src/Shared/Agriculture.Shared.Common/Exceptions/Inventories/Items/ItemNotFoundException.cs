using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Inventories.Items
{
    public class ItemNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Item '{0}' is not found.";

        public ItemNotFoundException(string itemIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, itemIdentifier))
        {
        }
    }
}
