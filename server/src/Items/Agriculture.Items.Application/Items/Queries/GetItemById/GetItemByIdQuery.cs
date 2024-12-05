using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Items.Application.Items.Queries.GetItemById
{
    public record GetItemByIdQuery(string Id) : IQuery<GetItemByIdQueryResult>;
}
