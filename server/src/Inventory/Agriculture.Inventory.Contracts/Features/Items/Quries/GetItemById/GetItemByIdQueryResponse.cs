namespace Agriculture.Inventory.Contracts.Features.Items.Quries.GetItemById
{
    public class GetItemByIdQueryResponse
    {
        public string Id { get; set; }
        public string CatalogNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
