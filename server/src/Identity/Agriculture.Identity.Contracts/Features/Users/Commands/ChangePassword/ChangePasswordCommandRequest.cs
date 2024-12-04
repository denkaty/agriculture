using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Contracts.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandRequest
    {
        [FromBody]
        public ChangePasswordCommandBindingModel ChangePasswordCommandBindingModel { get; set; } = new(string.Empty, string.Empty);
    }
}
