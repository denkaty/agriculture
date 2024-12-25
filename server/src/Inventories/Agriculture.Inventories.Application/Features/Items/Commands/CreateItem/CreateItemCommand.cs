using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Items.Commands.CreateItem
{
    public record CreateItemCommand(
        string CatalogNumber,
        string Name,
        string Description) : ICommand<CreateItemCommandResult>;
}
