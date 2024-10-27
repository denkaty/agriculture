using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Web.Features.Users.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("v1");
        }
    }
}
