using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder;
using Mapster;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateSellOrder
{
    public class ValidateSellOrderQueryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ValidateSellOrderQueryRequest, ValidateSellOrderQuery>()
                  .ConstructUsing(src => new(src.ValidateSellOrderQueryBindingModel.InventorySellItemOrders));

            config.NewConfig<InventoryCompositeKey, NotFoundCompositeKeyInventory>()
                  .Map(dest => dest.CompositeKey, src => src);

            config.NewConfig<(InventoryCompositeKey CompositeKey, int RequestedQuantity, int AvailableQuantity), InsufficientQuantityInventory>()
                .Map(dest => dest.CompositeKey, src => src.CompositeKey)
                .Map(dest => dest.RequestedQuantity, src => src.RequestedQuantity)
                .Map(dest => dest.AvailableQuantity, src => src.AvailableQuantity);

            config.NewConfig<(ICollection<NotFoundCompositeKeyInventory>, ICollection<InsufficientQuantityInventory>), ValidateSellOrderQueryResult>()
                .Map(dest => dest.NotFoundCompositeKeyInventories, src => src.Item1)
                .Map(dest => dest.InsufficientQuantityInventories, src => src.Item2)
                .Map(dest => dest.IsValid, src => !src.Item1.Any() && !src.Item2.Any());


            //config.NewConfig<ICollection<(string ItemId, string WarehouseId)>, ValidateSellOrderQueryResult>()
            //    .Map(dest => dest.IsValid, src => !src.Any())
            //    .Map(dest => dest.InvalidInventoryBuyItemOrders, src => src);

            //config.NewConfig<ValidateBuyOrderQueryResult, ValidateBuyOrderQueryResponse>()
            //    .Map(dest => dest.IsValid, src => src.IsValid)
            //    .Map(dest => dest.InvalidInventoryBuyItemOrders, src =>
            //    src.InvalidInventoryBuyItemOrders.Select(k => new InventoryBuyItemOrder
            //    {
            //        ItemId = k.ItemId,
            //        WarehouseId = k.WarehouseId
            //    }).ToList());
        }
    }
}
