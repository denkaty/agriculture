using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateSellOrder
{
    public class ValidateSellOrderQueryResult
    {
        public bool IsValid { get; set; }
        public ICollection<NotFoundCompositeKeyInventory> NotFoundCompositeKeyInventories { get; set; }
        public ICollection<InsufficientQuantityInventory> InsufficientQuantityInventories { get; set; }
    }
}
