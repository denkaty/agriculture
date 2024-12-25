using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Inventories.Warehouses
{
    public class WarehouseEmptyCollectionException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "No warehouses were found";

        public WarehouseEmptyCollectionException() : base(ERROR_MESSAGE_TEMPLATE)
        {
        }
    }
}
