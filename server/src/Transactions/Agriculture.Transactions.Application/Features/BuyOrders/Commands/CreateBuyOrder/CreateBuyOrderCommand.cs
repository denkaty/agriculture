using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Transactions.Contracts.Features.BuyOrders.Commands.CreateBuyOrder;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Commands.CreateBuyOrder
{
    public record CreateBuyOrderCommand(
        string SupplierId,
        DateTime OrderDate,
        ICollection<CreateBuyOrderItemBindingModel> Items) : ICommand<CreateBuyOrderCommandResult>;
}
