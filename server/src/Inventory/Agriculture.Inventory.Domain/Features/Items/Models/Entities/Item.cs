using Agriculture.Shared.Domain.Models.Base;

namespace Agriculture.Inventory.Domain.Features.Items.Models.Entities
{
    public class Item : Entity
    {
        public string CatalogNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
