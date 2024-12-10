using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Agriculture.Shared.Domain.Models.Base;

namespace Agriculture.Inventories.Domain.Features.Items.Models.Entities
{
    public class Item : Entity
    {
        public string CatalogNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
