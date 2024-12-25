using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Models.Pagination;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoryByItemId
{
    public record GetInventoriesByItemIdQuery(
       string ItemId,
       int Page,
       int PageSize,
       string SortBy,
       string SortOrder,
       string SearchTerm)
       : PaginatedSortedQuery(Page, PageSize, SortBy, SortOrder, SearchTerm), IQuery<GetInventoriesByItemIdQueryResult>;
}
