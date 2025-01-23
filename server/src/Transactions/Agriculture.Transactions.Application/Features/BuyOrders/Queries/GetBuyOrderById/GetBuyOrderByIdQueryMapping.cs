using Agriculture.Transactions.Contracts.Features.BuyOrders.Queries.GetBuyOrderById;
using Agriculture.Transactions.Domain.Features.BuyOrders.Models.Entities;
using Mapster;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Queries.GetBuyOrderById
{
    public class GetBuyOrderByIdQueryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<BuyOrder, GetBuyOrderByIdQueryResult>();

            config.NewConfig<BuyOrderItem, BuyOrderItemViewModel>();
        }
    }
}
