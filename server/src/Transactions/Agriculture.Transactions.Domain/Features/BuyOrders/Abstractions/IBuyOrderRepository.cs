using Agriculture.Shared.Domain.Abstractions;
using Agriculture.Transactions.Domain.Features.BuyOrders.Models.Entities;

namespace Agriculture.Transactions.Domain.Features.BuyOrders.Abstractions
{
    public interface IBuyOrderRepository : IRepository<BuyOrder>
    {
    }
}
