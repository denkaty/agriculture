using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Web.Utilities;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Agriculture.Transactions.Web.Features.Suppliers.Controllers.v1
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/inventories")]
    [EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
    public class SuppliersController : ControllerBase
    {
        private readonly IAgricultureMapper _agricultureMapper;
        private readonly IAgricultureSender _agricultureSender;

        public SuppliersController(IAgricultureMapper agricultureMapper, IAgricultureSender agricultureSender)
        {
            _agricultureMapper = agricultureMapper;
            _agricultureSender = agricultureSender;
        }
    }
}
