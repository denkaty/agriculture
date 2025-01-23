using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.Clients
{
    public class ClientNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Client '{0}' is not found.";

        public ClientNotFoundException(string supplierIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, supplierIdentifier))
        {
        }
    }
}
