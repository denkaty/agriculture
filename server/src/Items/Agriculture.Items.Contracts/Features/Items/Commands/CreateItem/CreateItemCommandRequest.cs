using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Items.Contracts.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandRequest
    {
        [FromBody]
        public CreateItemCommandBindingModel CreateItemCommandBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty);
    }
}
