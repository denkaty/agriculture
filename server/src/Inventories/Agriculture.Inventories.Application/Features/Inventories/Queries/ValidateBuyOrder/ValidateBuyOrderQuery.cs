using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateBuyOrder;
using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateBuyOrder
{
    public record ValidateBuyOrderQuery(ICollection<InventoryBuyItemOrder> InventoryBuyItemOrders) : IQuery<ValidateBuyOrderQueryResult>;
}
