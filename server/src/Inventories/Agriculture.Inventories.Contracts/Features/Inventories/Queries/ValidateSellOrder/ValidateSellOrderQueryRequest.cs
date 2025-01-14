using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder
{
    public class ValidateSellOrderQueryRequest
    {
        [FromBody]
        public ValidateSellOrderQueryBindingModel ValidateSellOrderQueryBindingModel { get; set; } = new([]);
    }
}
