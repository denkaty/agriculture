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
                  .ConstructUsing(src => new(src.ValidateBuyOrderQueryBindingModel.InventoryBuyItemOrders));

            config.NewConfig<ICollection<(string ItemId, string WarehouseId)>, ValidateBuyOrderQueryResult>()
                .Map(dest => dest.IsValid, src => !src.Any())
                .Map(dest => dest.InvalidInventoryBuyItemOrders, src => src);

            config.NewConfig<ValidateBuyOrderQueryResult, ValidateBuyOrderQueryResponse>()
                .Map(dest => dest.IsValid, src => src.IsValid)
                .Map(dest => dest.InvalidInventoryBuyItemOrders, src =>
                src.InvalidInventoryBuyItemOrders.Select(k => new InventoryBuyItemOrder
                {
                    ItemId = k.ItemId,
                    WarehouseId = k.WarehouseId
                }).ToList());
        }
    }
}
