using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.SellOrders
{
    public class SellOrderInventoryNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "The following inventory composite keys in the sell order are invalid: {0}";

        public SellOrderInventoryNotFoundException(string invalidKeysMessage) : base(string.Format(ERROR_MESSAGE_TEMPLATE, invalidKeysMessage))
        {
        }
    }
}
