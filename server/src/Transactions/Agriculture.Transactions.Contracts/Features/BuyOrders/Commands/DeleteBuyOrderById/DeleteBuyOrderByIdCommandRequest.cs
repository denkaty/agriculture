using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.BuyOrders.Commands.DeleteBuyOrderById
{
    public class DeleteBuyOrderByIdCommandRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
