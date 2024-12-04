using Agriculture.Identity.Contracts.Features.Users.Register;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Web.Features.Users.Models.Requests
{
    public class RegisterCommandRequest
    {
        [FromBody]
        public RegisterCommandBindingModel RegisterCommandBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
    }
}
