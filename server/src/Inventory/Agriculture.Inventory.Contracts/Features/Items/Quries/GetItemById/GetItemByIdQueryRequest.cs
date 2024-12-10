using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Inventory.Contracts.Features.Items.Quries.GetItemById
{
    public class GetItemByIdQueryRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
