using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Transactions.Application.Features.Suppliers.Queries.GetSupplierById
{
    public record GetSupplierByIdQuery(string Id) : IQuery<GetSupplierByIdQueryResult>;
}
