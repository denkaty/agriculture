namespace Agriculture.Transactions.Contracts.Features.Clients.Queries.GetClients
{
    public class GetClientsQueryResponse
    {
        public IReadOnlyCollection<GetClientsQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
