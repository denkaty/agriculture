using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.BuyOrders
{
    public class BuyOrderNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Buy Order '{0}' is not found.";

        public BuyOrderNotFoundException(string buyOrderIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, buyOrderIdentifier))
        {
        }
    }
}
