using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Commands.DeleteBuyOrderById
{
    public record DeleteBuyOrderByIdCommand(string Id) : ICommand;
}
