namespace Agriculture.Inventories.Contracts.Features.Warehouses.Commands.CreateWarehouse
{
    public class CreateWarehouseCommandBindingModel
    {
        public CreateWarehouseCommandBindingModel(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
