using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Contracts.Features.SellOrders.Commands.CreateSellOrder
{
    public class CreateSellOrderCommandRequest
    {
        [FromBody]
        public CreateSellOrderCommandBindingModel CreateSellOrderCommandBindingModel { get; set; } = new(string.Empty, DateTime.UtcNow, new List<CreateSellOrderItemBindingModel>());

    }
}
