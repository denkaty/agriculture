using Agriculture.Shared.Domain.Models.Base;
using Agriculture.Transactions.Domain.Features.Clients.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Transactions.Domain.Features.SellOrders.Models
{
    public class SellOrder : Entity
    {
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<SellOrderItem> Items { get; set; } = new List<SellOrderItem>();
    }
}
