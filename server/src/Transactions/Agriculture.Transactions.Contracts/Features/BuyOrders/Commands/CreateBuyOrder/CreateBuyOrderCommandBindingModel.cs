namespace Agriculture.Transactions.Contracts.Features.BuyOrders.Commands.CreateBuyOrder
{
    public class CreateBuyOrderCommandBindingModel
    {
        public CreateBuyOrderCommandBindingModel(string supplierId, DateTime orderDate, ICollection<CreateBuyOrderItemBindingModel> items)
        {
            SupplierId = supplierId;
            OrderDate = orderDate;
            Items = items;
        }

        public string SupplierId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public ICollection<CreateBuyOrderItemBindingModel> Items { get; set; } = new List<CreateBuyOrderItemBindingModel>();
    }
}
