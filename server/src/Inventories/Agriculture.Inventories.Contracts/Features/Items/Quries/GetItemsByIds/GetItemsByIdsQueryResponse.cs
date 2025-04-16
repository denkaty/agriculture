using Agriculture.Inventories.Contracts.Features.Items.Quries.GetItems;

namespace Agriculture.Inventories.Contracts.Features.Items.Quries.GetItemsById
{
    public class GetItemsByIdsQueryResponse
    {
        public IReadOnlyCollection<GetItemsByIdsQueryViewModel> Data { get; set; }

    }
}
