using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Transactions.Application.Features.Suppliers.Commands.DeleteSupplierById
{
    public record DeleteSupplierByIdCommand(string Id) : ICommand;
}
