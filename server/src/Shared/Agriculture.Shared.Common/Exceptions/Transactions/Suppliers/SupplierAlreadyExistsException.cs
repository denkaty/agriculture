using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.Suppliers
{
    public class SupplierAlreadyExistsException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Supplier '{0}' already exists.";

        public SupplierAlreadyExistsException(string supplierIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, supplierIdentifier))
        {
        }
    }
}
