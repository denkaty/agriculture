using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Inventories.Contracts.Features.Items.Quries.GetItemsById
{
    public class GetItemsByIdsQueryRequest
    {
        [FromBody]
        public ICollection<string> Ids { get; set; }
    }
}
