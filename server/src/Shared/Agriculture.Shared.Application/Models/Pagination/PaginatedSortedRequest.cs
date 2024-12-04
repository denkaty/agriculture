using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Shared.Application.Models.Pagination
{
    public abstract class PaginatedSortedRequest
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = 10;

        [FromQuery(Name = "sortBy")]
        public string SortBy { get; set; } = "";

        [FromQuery(Name = "sortOrder")]
        public string SortOrder { get; set; } = "asc";

        [FromQuery(Name = "searchTerm")]
        public string SearchTerm { get; set; } = "";
    }
}
