namespace Agriculture.Transactions.Contracts.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPerson { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
