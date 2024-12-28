using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.Clients.Commands
{
    public class CreateClientCommandRequest
    {
        [FromBody]
        public CreateClientCommandBindingModel CreateSupplierCommandBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
    }
}
