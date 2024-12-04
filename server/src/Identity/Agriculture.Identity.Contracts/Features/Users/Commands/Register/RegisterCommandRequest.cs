using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Contracts.Features.Users.Commands.Register
{
    public class RegisterCommandRequest
    {
        [FromBody]
        public RegisterCommandBindingModel RegisterCommandBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
    }
}
