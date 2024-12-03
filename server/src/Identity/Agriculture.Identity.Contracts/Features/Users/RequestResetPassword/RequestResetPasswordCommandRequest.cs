using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Contracts.Features.Users.ResetPassword
{
    public class RequestResetPasswordCommandRequest
    {
        [FromRoute]
        public string Email { get; set; } = string.Empty;
    }
}
