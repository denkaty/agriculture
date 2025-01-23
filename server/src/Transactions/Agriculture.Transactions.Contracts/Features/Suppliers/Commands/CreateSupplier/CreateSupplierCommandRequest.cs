using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandRequest
    {
        [FromBody]
        public CreateSupplierCommandBindingModel CreateSupplierCommandBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
    }
}
