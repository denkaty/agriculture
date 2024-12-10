using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventory.Application.Items.Queries.GetItemById
{
    public record GetItemByIdQuery(string Id) : IQuery<GetItemByIdQueryResult>;
}
