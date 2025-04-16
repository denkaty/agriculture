using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder;
using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateSellOrder
{
    public record ValidateSellOrderQuery(ICollection<InventorySellItemOrder> InventorySellItemOrders) : IQuery<ValidateSellOrderQueryResult>;
}
