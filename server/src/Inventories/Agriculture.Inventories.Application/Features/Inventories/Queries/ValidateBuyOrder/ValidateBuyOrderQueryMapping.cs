using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateBuyOrder;
using Agriculture.Shared.Common.Features.Transactions.Queries.ValidateBuyOrder;
using Mapster;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateBuyOrder
{
    public class ValidateBuyOrderQueryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ValidateBuyOrderQueryRequest, ValidateBuyOrderQuery>()
                  .ConstructUsing(src => new(src.ValidateBuyOrderQueryBindingModel.CompositeKeys));

            config.NewConfig<ICollection<(string ItemId, string WarehouseId)>, ValidateBuyOrderQueryResult>()
                .Map(dest => dest.IsValid, src => !src.Any())
                .Map(dest => dest.InvalidCompositeKeys, src => src);

            config.NewConfig<ValidateBuyOrderQueryResult, ValidateBuyOrderQueryResponse>()
                .Map(dest => dest.IsValid, src => src.IsValid)
                .Map(dest => dest.InvalidCompositeKeys, src =>
                src.InvalidCompositeKeys.Select(k => new InventoryCompositeKey
                {
                    ItemId = k.ItemId,
                    WarehouseId = k.WarehouseId
                }).ToList());
        }
    }
}
