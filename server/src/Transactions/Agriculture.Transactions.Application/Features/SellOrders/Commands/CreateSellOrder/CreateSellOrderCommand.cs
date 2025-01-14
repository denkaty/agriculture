using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Transactions.Contracts.Features.SellOrders.Commands.CreateSellOrder;

namespace Agriculture.Transactions.Application.Features.SellOrders.Commands.CreateSellOrder
{
    public record CreateSellOrderCommand(
        string ClientId,
        DateTime OrderDate,
        ICollection<CreateSellOrderItemBindingModel> Items) : ICommand<CreateSellOrderCommandResult>;
}
