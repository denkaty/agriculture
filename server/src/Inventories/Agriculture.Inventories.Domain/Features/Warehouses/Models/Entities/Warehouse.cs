using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Agriculture.Shared.Domain.Models.Base;

namespace Agriculture.Inventories.Domain.Features.Warehouses.Models.Entities
{
    public class Warehouse : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
