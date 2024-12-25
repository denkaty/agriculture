using Agriculture.Inventories.Contracts.Features.Inventories.Commands.Transfer;
using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Inventories.Commands.Transfer
{
    public record TransferCommand(
        string SourceWarehouseId,
        string DestinationWarehouseId,
        ICollection<TransferItem> Items) : ICommand;
}
