using Agriculture.Inventory.Contracts.Features.Items.Commands.CreateItem;
using Mapster;

namespace Agriculture.Inventory.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateItemCommandRequest, CreateItemCommand>()
                  .ConstructUsing(src => new(src.CreateItemCommandBindingModel.CatalogNumber, src.CreateItemCommandBindingModel.Name, src.CreateItemCommandBindingModel.Description));

        }
    }
}
