using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Inventories.Warehouses
{
    public class WarehouseNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Warehouse '{0}' is not found.";

        public WarehouseNotFoundException(string warehouseIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, warehouseIdentifier))
        {
        }
    }
}
