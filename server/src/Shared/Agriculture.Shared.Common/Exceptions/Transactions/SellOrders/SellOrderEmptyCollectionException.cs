using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.SellOrders
{
    public class SellOrderEmptyCollectionException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "No sell orders were found";

        public SellOrderEmptyCollectionException() : base(ERROR_MESSAGE_TEMPLATE)
        {
        }
    }
}
