using Agriculture.Inventories.Contracts.Features.Warehouses.Commands.CreateWarehouse;
using Mapster;

namespace Agriculture.Inventories.Application.Features.Warehouses.Commands.CreateWarehouse
{
    public class CreateWarehouseCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateWarehouseCommandRequest, CreateWarehouseCommand>()
                  .ConstructUsing(src => new(src.CreateWarehouseCommandBindingModel.Name, src.CreateWarehouseCommandBindingModel.Location));

        }
    }
}
