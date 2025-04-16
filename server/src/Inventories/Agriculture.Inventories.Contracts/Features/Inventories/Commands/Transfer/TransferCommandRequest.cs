using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Inventories.Contracts.Features.Inventories.Commands.Transfer
{
    public class TransferCommandRequest
    {
        [FromBody]
        public TransferCommandBindingModel TransferCommandBindingModel { get; set; } = new(string.Empty, string.Empty, []);
    }
}
