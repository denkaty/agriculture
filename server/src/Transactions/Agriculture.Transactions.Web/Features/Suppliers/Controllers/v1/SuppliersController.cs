using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Web.Utilities;
using Agriculture.Transactions.Application.Features.Suppliers.Commands.CreateSupplier;
using Agriculture.Transactions.Contracts.Features.Suppliers.Commands.CreateSupplier;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Agriculture.Transactions.Web.Features.Suppliers.Controllers.v1
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/suppliers")]
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

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateSupplierCommandRequest request, CancellationToken cancellationToken)
        {
            var createSupplierCommand = _agricultureMapper.Map<CreateSupplierCommand>(request);

            var createSupplierCommandResult = await _agricultureSender.SendAsync(createSupplierCommand, cancellationToken);

            var createSupplierCommandResponse = _agricultureMapper.Map<CreateSupplierCommandResponse>(createSupplierCommandResult);

            return Ok(createSupplierCommandResponse);
        }
        /*
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetSupplierByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getSupplierByIdQuery = _agricultureMapper.Map<GetSupplierByIdQuery>(request);

            var getSupplierByIdQueryResult = await _agricultureSender.SendAsync(getSupplierByIdQuery, cancellationToken);

            var getSupplierByIdQueryResponse = _agricultureMapper.Map<GetSupplierByIdQueryResponse>(getSupplierByIdQueryResult);

            return Ok(getSupplierByIdQueryResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(GetSuppliersQueryRequest request, CancellationToken cancellationToken)
        {
            var getSuppliersQuery = _agricultureMapper.Map<GetSuppliersQuery>(request);

            var getSuppliersQueryResult = await _agricultureSender.SendAsync(getSuppliersQuery, cancellationToken);

            var getSuppliersQueryResponse = _agricultureMapper.Map<GetSuppliersQueryResponse>(getSuppliersQueryResult);

            return Ok(getSuppliersQueryResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync(DeleteSupplierByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteSupplierByIdCommand = _agricultureMapper.Map<DeleteSupplierByIdCommand>(request);

            await _agricultureSender.SendAsync(deleteSupplierByIdCommand, cancellationToken);

            return NoContent();
        }
        */
    }
}
