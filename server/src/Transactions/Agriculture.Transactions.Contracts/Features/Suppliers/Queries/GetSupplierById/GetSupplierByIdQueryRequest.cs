using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQueryRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
