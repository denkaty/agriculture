using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Items.Contracts.Features.Items.Commands.DeleteItemById
{
    public class DeleteItemByIdCommandRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
