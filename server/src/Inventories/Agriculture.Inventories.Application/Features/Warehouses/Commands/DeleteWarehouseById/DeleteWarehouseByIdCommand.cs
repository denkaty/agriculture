using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Warehouses.Commands.DeleteWarehouseById
{
    public record DeleteWarehouseByIdCommand(string Id) : ICommand;
}
