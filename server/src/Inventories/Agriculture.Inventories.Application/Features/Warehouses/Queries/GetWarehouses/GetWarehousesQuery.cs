using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Models.Pagination;

namespace Agriculture.Inventories.Application.Features.Warehouses.Queries.GetWarehouses
{
    public record GetWarehousesQuery(
       int Page,
       int PageSize,
       string SortBy,
       string SortOrder,
       string SearchTerm)
       : PaginatedSortedQuery(Page, PageSize, SortBy, SortOrder, SearchTerm), IQuery<GetWarehousesQueryResult>;
}
