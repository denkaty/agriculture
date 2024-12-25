using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Warehouses.Commands.CreateWarehouse
{
    public record CreateWarehouseCommand(
        string Name,
        string Location) : ICommand<CreateWarehouseCommandResult>;
}
