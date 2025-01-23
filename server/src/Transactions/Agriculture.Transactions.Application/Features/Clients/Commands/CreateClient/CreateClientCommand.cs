using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Transactions.Application.Features.Clients.Commands.CreateClient
{
    public record CreateClientCommand(
        string TaxIdentificationNumber,
        string Name,
        string Email,
        string PhoneNumber,
        string Address,
        string? ContactPerson) : ICommand<CreateClientCommandResult>;
}
