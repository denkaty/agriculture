namespace Agriculture.Shared.Application.Models.Pagination
{
    public abstract record PaginatedSortedQuery(int Page, int PageSize, string SortBy, string SortOrder, string SearchTerm);
}
