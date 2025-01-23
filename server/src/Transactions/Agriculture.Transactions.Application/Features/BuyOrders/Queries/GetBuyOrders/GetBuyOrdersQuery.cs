using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Models.Pagination;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Queries.GetBuyOrders
{
    public record GetBuyOrdersQuery(
        int Page,
        int PageSize,
        string SortBy,
        string SortOrder,
        string SearchTerm)
        : PaginatedSortedQuery(Page, PageSize, SortBy, SortOrder, SearchTerm), IQuery<GetBuyOrdersQueryResult>;
}
