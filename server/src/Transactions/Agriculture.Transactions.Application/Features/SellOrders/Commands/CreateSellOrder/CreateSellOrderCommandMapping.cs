using Agriculture.Transactions.Contracts.Features.SellOrders.Commands.CreateSellOrder;
using Agriculture.Transactions.Domain.Features.SellOrders.Models;
using Mapster;

namespace Agriculture.Transactions.Application.Features.SellOrders.Commands.CreateSellOrder
{
    public class CreateSellOrderCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateSellOrderCommandRequest, CreateSellOrderCommand>()
                .ConstructUsing(src => new(
                    src.CreateSellOrderCommandBindingModel.ClientId,
                    src.CreateSellOrderCommandBindingModel.OrderDate,
                    src.CreateSellOrderCommandBindingModel.Items
                ));

            config.NewConfig<CreateSellOrderCommand, SellOrder>()
                .Map(dest => dest.ClientId, src => src.ClientId)
                .Map(dest => dest.OrderDate, src => src.OrderDate)
                .Map(dest => dest.TotalAmount, src => src.Items.Sum(item => item.Quantity * item.UnitPrice))
                .Map(dest => dest.Items, src => src.Items.Select(item => new SellOrderItem
                {
                    ItemId = item.ItemId,
                    WarehouseId = item.WarehouseId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    SubTotal = item.Quantity * item.UnitPrice
                }).ToList())
                .AfterMapping((src, dest) =>
                {
                    foreach (var item in dest.Items)
                    {
                        item.SellOrderId = dest.Id;
                    }
                });

            //config.NewConfig<CreateSellOrderCommand, ValidateSellOrderQueryRequest>()
            //    .Map(dest => dest.CompositeKeys, src => src.Items.Select(x => new InventoryCompositeKey
            //    {
            //        ItemId = x.ItemId,
            //        WarehouseId = x.WarehouseId
            //    }).ToList());
        }
    }
}
