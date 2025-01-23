using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.Clients.Commands.DeleteClientById
{
    public class DeleteClientByIdCommandRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
