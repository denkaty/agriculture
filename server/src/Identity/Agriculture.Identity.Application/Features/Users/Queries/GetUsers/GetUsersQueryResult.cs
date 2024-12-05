using Agriculture.Identity.Contracts.Features.Users.Queries.GetUsers;

namespace Agriculture.Identity.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryResult
    {
        public IReadOnlyCollection<GetUsersQueryViewModel> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;
    }

}
