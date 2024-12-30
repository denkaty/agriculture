using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.BuyOrders.Queries.GetBuyOrderById
{
    public class GetBuyOrderByIdQueryRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
