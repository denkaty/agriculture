using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.Clients
{
    public class ClientEmptyCollectionException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "No clients were found";

        public ClientEmptyCollectionException() : base(ERROR_MESSAGE_TEMPLATE)
        {
        }
    }
}
