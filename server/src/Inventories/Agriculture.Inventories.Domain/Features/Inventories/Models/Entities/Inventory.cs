using Agriculture.Inventories.Domain.Features.Items.Models.Entities;
using Agriculture.Inventories.Domain.Features.Warehouses.Models.Entities;
using Agriculture.Shared.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Inventories.Domain.Features.Inventories.Models.Entities
{
    public class Inventory : Entity
    {
        [ForeignKey(nameof(Item))]
        public string ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey(nameof(Warehouse))]
        public string WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public int Quantity { get; set; }
    }
}
