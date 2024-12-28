using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
