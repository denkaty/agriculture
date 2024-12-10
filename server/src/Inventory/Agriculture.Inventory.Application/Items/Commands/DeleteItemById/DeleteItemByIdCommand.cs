using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventory.Application.Items.Commands.DeleteItemById
{
    public record DeleteItemByIdCommand(string Id) : ICommand;
}
