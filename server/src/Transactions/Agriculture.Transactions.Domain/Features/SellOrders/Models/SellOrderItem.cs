using Agriculture.Shared.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Transactions.Domain.Features.SellOrders.Models
{
    public class SellOrderItem : Entity
    {
        public string ItemId { get; set; }
        public string WarehouseId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

        [ForeignKey(nameof(SellOrder))]
        public string SellOrderId { get; set; }
        public SellOrder SellOrder { get; set; }
    }
}
