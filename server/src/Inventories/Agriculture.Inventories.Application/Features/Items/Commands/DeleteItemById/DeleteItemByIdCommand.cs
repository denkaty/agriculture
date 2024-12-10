using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Items.Commands.DeleteItemById
{
    public record DeleteItemByIdCommand(string Id) : ICommand;
}
