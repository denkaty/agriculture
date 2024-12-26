using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Transactions.Application.Features.Suppliers.Commands.CreateSupplier
{
    public record CreateSupplierCommand(
        string TaxIdentificationNumber,
        string Name,
        string Email,
        string PhoneNumber,
        string Address,
        string? ContactPerson) : ICommand<CreateSupplierCommandResult>;
}
