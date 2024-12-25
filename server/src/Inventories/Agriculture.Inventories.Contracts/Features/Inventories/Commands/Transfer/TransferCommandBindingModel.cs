namespace Agriculture.Inventories.Contracts.Features.Inventories.Commands.Transfer
{
    public class TransferCommandBindingModel
    {
        public TransferCommandBindingModel(string sourceWarehouseId, string destinationWarehouseId, ICollection<TransferItem> items) 
        {
            SourceWarehouseId = sourceWarehouseId;
            DestinationWarehouseId = destinationWarehouseId;
            Items = items;
        }
        public string SourceWarehouseId { get; set; }
        public string DestinationWarehouseId { get; set; }
        public ICollection<TransferItem> Items { get; set; }
    }
}
