using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.Suppliers
{
    public class SupplierNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Supplier '{0}' is not found.";

        public SupplierNotFoundException(string supplierIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, supplierIdentifier))
        {
        }
    }
}
