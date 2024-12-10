using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Inventories.Items
{
    public class ItemAlreadyExistsException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Item '{0}' already exists.";

        public ItemAlreadyExistsException(string email) : base(string.Format(ERROR_MESSAGE_TEMPLATE, email))
        {
        }
    }
}
