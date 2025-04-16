using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Models.Pagination;

namespace Agriculture.Transactions.Application.Features.Suppliers.Queries.GetSuppliers
{
    public record GetSuppliersQuery(
        int Page,
        int PageSize,
        string SortBy,
        string SortOrder,
        string SearchTerm)
        : PaginatedSortedQuery(Page, PageSize, SortBy, SortOrder, SearchTerm), IQuery<GetSuppliersQueryResult>;
}
