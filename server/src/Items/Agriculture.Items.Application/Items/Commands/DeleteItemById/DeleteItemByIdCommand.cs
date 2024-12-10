using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Items.Application.Items.Commands.DeleteItemById
{
    public record DeleteItemByIdCommand(string Id) : ICommand;
}
