using Microsoft.AspNetCore.Mvc;
namespace Agriculture.Shared.Common.Features.Transactions.Queries.ValidateBuyOrder
{
    public class ValidateBuyOrderQueryRequest
    {
        [FromBody]
        public ValidateBuyOrderQueryBindingModel ValidateBuyOrderQueryBindingModel { get; set; } = new([]);
    }
}
