using Agriculture.Inventories.Contracts.Features.Items.Quries.GetItemsById;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItemsByIds
{
    public class GetItemsByIdsQueryResult
    {
        public IReadOnlyCollection<GetItemsByIdsQueryViewModel> Data { get; set; }
    }
}
