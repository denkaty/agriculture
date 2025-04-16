using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Models.Pagination;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItems
{
    public record GetItemsQuery(
       int Page,
       int PageSize,
       string SortBy,
       string SortOrder,
       string SearchTerm)
       : PaginatedSortedQuery(Page, PageSize, SortBy, SortOrder, SearchTerm), IQuery<GetItemsQueryResult>;
}
