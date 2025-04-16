using Agriculture.Transactions.Contracts.Features.BuyOrders.Queries.GetBuyOrders;
using Agriculture.Transactions.Domain.Features.BuyOrders.Models.Entities;
using Mapster;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Queries.GetBuyOrders
{
    public class GetBuyOrdersQueryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<BuyOrder, GetBuyOrdersQueryViewModel>()
                .Map(src => src.SupplierName, dest => dest.Supplier.Name);
        }
    }
}
