using Agriculture.Shared.Domain.Abstractions;
using Agriculture.Transactions.Domain.Features.SellOrders.Models;

namespace Agriculture.Transactions.Domain.Features.SellOrders.Abstractions
{
    public interface ISellOrderRepository : IRepository<SellOrder>
    {
    }
}
