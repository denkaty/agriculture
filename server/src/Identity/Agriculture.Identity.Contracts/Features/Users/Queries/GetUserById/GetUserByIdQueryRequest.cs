using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Contracts.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryRequest
    {
        [FromRoute(Name = "id")]
        public string Id { get; set; } = string.Empty;
    }
}
