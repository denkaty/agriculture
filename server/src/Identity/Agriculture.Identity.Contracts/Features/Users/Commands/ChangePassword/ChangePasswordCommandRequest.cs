using Agriculture.Shared.Web.Binders.FromClaim;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace Agriculture.Identity.Contracts.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandRequest
    {
        [FromBody]
        public ChangePasswordCommandBindingModel ChangePasswordCommandBindingModel { get; set; } = new(string.Empty, string.Empty);

        [FromClaim(ClaimTypes.NameIdentifier)]
        [SwaggerIgnore]
        public string CurrentUserId { get; set; } = string.Empty;
    }
}
