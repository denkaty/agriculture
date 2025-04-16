using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Transactions.Application.Features.Clients.Commands.DeleteClientById
{
    public record DeleteClientByIdCommand(string Id) : ICommand;
}
