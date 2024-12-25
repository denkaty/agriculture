namespace Agriculture.Inventories.Contracts.Features.Warehouses.Queries.GetWarehouseById
{
    public class GetWarehouseByIdQueryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
