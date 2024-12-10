namespace Agriculture.Inventory.Contracts.Features.Items.Quries.GetItems
{
    public class GetItemsQueryResponse
    {
        public IReadOnlyCollection<GetItemsQueryViewModel> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
