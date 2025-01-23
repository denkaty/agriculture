using Agriculture.Shared.Domain.Models.Base;
using Agriculture.Transactions.Domain.Features.Suppliers.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Transactions.Domain.Features.BuyOrders.Models.Entities
{
    public class BuyOrder : Entity
    {
        [ForeignKey(nameof(Supplier))]
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<BuyOrderItem> Items { get; set; } = new List<BuyOrderItem>();
    }
}
