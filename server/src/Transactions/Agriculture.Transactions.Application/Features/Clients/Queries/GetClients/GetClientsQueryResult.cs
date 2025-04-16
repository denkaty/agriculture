using Agriculture.Transactions.Contracts.Features.Clients.Queries.GetClients;

namespace Agriculture.Transactions.Application.Features.Clients.Queries.GetClients
{
    public class GetClientsQueryResult
    {
        public IReadOnlyCollection<GetClientsQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage => Page * PageSize < TotalCount;
        public bool HasPreviousPage => Page > 1;
    }
}
