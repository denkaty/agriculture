using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItemById
{
    public record GetItemByIdQuery(string Id) : IQuery<GetItemByIdQueryResult>;
}
