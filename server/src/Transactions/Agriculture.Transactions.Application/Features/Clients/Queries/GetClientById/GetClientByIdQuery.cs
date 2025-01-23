using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Transactions.Application.Features.Clients.Queries.GetClientById
{
    public record GetClientByIdQuery(string Id) : IQuery<GetClientByIdQueryResult>;
}
