using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.Suppliers.Commands.DeleteSupplierById
{
    public class DeleteSupplierByIdCommandRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
