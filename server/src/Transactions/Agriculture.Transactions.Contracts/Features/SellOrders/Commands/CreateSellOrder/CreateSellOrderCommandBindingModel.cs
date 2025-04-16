namespace Agriculture.Transactions.Contracts.Features.SellOrders.Commands.CreateSellOrder
{
    public class CreateSellOrderCommandBindingModel
    {
        public CreateSellOrderCommandBindingModel(string clientId, DateTime orderDate, ICollection<CreateSellOrderItemBindingModel> items)
        {
            ClientId = clientId;
            OrderDate = orderDate;
            Items = items;
        }

        public string ClientId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public ICollection<CreateSellOrderItemBindingModel> Items { get; set; } = new List<CreateSellOrderItemBindingModel>();
    }
}
