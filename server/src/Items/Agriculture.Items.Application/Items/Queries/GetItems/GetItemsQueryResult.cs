using Agriculture.Items.Contracts.Features.Items.Quries.GetItems;

namespace Agriculture.Items.Application.Items.Queries.GetItems
{
    public class GetItemsQueryResult
    {
        public IReadOnlyCollection<GetItemsQueryViewModel> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;
    }
}
