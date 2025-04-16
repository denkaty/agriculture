using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.Suppliers
{
    public class SupplierEmptyCollectionException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "No suppliers were found";

        public SupplierEmptyCollectionException() : base(ERROR_MESSAGE_TEMPLATE)
        {
        }
    }
}
