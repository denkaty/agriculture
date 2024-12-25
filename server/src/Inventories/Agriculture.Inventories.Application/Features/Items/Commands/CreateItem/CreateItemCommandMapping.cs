using Agriculture.Inventories.Contracts.Features.Items.Commands.CreateItem;
using Agriculture.Inventories.Domain.Features.Items.Models.Entities;
using Agriculture.Shared.Application.Events.Inventories.Items;
using Mapster;

namespace Agriculture.Inventories.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateItemCommandRequest, CreateItemCommand>()
                  .ConstructUsing(src => new(src.CreateItemCommandBindingModel.CatalogNumber, src.CreateItemCommandBindingModel.Name, src.CreateItemCommandBindingModel.Description));

            config.NewConfig<Item, ItemCreatedEvent>()
                 .Map(dest => dest.itemId, src => src.Id)
                 .Map(dest => dest.itemName, src => src.Name);
        }
    }
}
