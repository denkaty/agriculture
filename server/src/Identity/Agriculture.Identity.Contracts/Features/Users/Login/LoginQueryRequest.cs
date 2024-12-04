using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Contracts.Features.Users.Login
{
    public class LoginQueryRequest
    {
        [FromBody]
        public LoginQueryBindingModel LoginQueryBindingModel { get; set; } = new(string.Empty, string.Empty);
    }
}
