using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Queries.GetBuyOrderById
{
    public record GetBuyOrderByIdQuery(string Id) : IQuery<GetBuyOrderByIdQueryResult>;
}
