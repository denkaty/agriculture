using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.BuyOrders
{
    public class BuyOrderInventoryNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "The following inventory composite keys in the buy order are invalid: {0}";

        public BuyOrderInventoryNotFoundException(string invalidKeysMessage) : base(string.Format(ERROR_MESSAGE_TEMPLATE, invalidKeysMessage))
        {
        }
    }
}
