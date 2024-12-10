using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventory.Application.Items.Commands.CreateItem
{
    public record CreateItemCommand(
        string CatalogNumber,
        string Name,
        string Description) : ICommand<CreateItemCommandResult>;
}
