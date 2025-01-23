using Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateBuyOrder;
using Agriculture.Transactions.Contracts.Features.BuyOrders.Commands.CreateBuyOrder;
using Agriculture.Transactions.Domain.Features.BuyOrders.Models.Entities;
using Mapster;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Commands.CreateBuyOrder
{
    public class CreateBuyOrderCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateBuyOrderCommandRequest, CreateBuyOrderCommand>()
                .ConstructUsing(src => new(
                    src.CreateBuyOrderCommandBindingModel.SupplierId,
                    src.CreateBuyOrderCommandBindingModel.OrderDate,
                    src.CreateBuyOrderCommandBindingModel.Items
                ));

            config.NewConfig<CreateBuyOrderCommand, BuyOrder>()
                .Map(dest => dest.SupplierId, src => src.SupplierId)
                .Map(dest => dest.OrderDate, src => src.OrderDate)
                .Map(dest => dest.TotalAmount, src => src.Items.Sum(item => item.Quantity * item.UnitPrice))
                .Map(dest => dest.Items, src => src.Items.Select(item => new BuyOrderItem
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
                        item.BuyOrderId = dest.Id;
                    }
                });

            config.NewConfig<CreateBuyOrderCommand, ValidateBuyOrderQueryRequest>()
                .Map(dest => dest.CompositeKeys, src => src.Items.Select(x => new InventoryCompositeKey
                {
                    ItemId = x.ItemId,
                    WarehouseId = x.WarehouseId
                }).ToList());

        }


    }
}
