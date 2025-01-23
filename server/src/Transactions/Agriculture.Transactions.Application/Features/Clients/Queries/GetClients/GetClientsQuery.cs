using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Models.Pagination;

namespace Agriculture.Transactions.Application.Features.Clients.Queries.GetClients
{
    public record GetClientsQuery(
        int Page,
        int PageSize,
        string SortBy,
        string SortOrder,
        string SearchTerm)
        : PaginatedSortedQuery(Page, PageSize, SortBy, SortOrder, SearchTerm), IQuery<GetClientsQueryResult>;
}
