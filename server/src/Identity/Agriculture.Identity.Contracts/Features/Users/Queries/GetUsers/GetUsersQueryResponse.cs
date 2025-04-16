namespace Agriculture.Identity.Contracts.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryResponse
    {
        public IReadOnlyCollection<GetUsersQueryViewModel> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
