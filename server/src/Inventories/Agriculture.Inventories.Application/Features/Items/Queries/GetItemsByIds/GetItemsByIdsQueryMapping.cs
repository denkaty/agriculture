using Agriculture.Inventories.Contracts.Features.Items.Quries.GetItemsById;
using Agriculture.Inventories.Domain.Features.Items.Models.Entities;
using Mapster;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItemsByIds
{
    public class GetItemsByIdsQueryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Item, GetItemsByIdsQueryViewModel>();

            config.NewConfig<ICollection<Item>, GetItemsByIdsQueryResult>()
                  .Map(dest => dest.Data, src => src.Adapt<IReadOnlyCollection<GetItemsByIdsQueryViewModel>>());
        }
    }
}
