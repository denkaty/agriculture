using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Models.Pagination;

namespace Agriculture.Identity.Application.Features.Users.Queries.GetUsers
{
    public record GetUsersQuery(
       int Page,
       int PageSize,
       string SortBy,
       string SortOrder,
       string SearchTerm)
       : PaginatedSortedQuery(Page, PageSize, SortBy, SortOrder, SearchTerm), IQuery<GetUsersQueryResult>;
}
