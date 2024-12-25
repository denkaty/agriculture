namespace Agriculture.Shared.Domain.Models.Pagination
{
    public record PaginationList<T>(ICollection<T> Data, int Page, int PageSize, int TotalCount)
    {
        public bool HasNextPage => Page * PageSize < TotalCount;

        public bool HasPreviousPage => Page > 1;
    }

}
