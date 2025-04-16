using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItemsByIds
{
    public record GetItemsByIdsQuery(ICollection<string> Ids) : IQuery<GetItemsByIdsQueryResult>;

}
