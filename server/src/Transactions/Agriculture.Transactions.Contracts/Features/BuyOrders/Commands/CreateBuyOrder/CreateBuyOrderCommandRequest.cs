using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.BuyOrders.Commands.CreateBuyOrder
{
    public class CreateBuyOrderCommandRequest
    {
        [FromBody]
        public CreateBuyOrderCommandBindingModel CreateBuyOrderCommandBindingModel { get; set; } = new(string.Empty, DateTime.UtcNow, new List<CreateBuyOrderItemBindingModel>());
    }
}
