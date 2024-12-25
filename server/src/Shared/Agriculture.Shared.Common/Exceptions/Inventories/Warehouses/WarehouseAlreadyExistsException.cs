using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Inventories.Warehouses
{
    public class WarehouseAlreadyExistsException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Warehouse '{0}' already exists.";

        public WarehouseAlreadyExistsException(string warehouseIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, warehouseIdentifier))
        {
        }
    }
}
