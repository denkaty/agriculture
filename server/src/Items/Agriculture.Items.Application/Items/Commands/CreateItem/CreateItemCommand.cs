using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Items.Application.Items.Commands.CreateItem
{
    public record CreateItemCommand(
        string CatalogNumber,
        string Name,
        string Description) : ICommand<CreateItemCommandResult>;
}
