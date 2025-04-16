using Agriculture.Shared.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Transactions.Domain.Features.BuyOrders.Models.Entities
{
    public class BuyOrderItem : Entity
    {
        public string ItemId { get; set; }
        public string WarehouseId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

        [ForeignKey(nameof(BuyOrder))]
        public string BuyOrderId { get; set; }
        public BuyOrder BuyOrder { get; set; }
    }
}
