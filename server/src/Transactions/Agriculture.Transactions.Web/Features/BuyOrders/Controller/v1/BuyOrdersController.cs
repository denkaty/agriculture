using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Web.Utilities;
using Agriculture.Transactions.Application.Features.BuyOrders.Commands.CreateBuyOrder;
using Agriculture.Transactions.Application.Features.Clients.Commands.CreateClient;
using Agriculture.Transactions.Application.Features.Clients.Commands.DeleteClientById;
using Agriculture.Transactions.Application.Features.Clients.Queries.GetClientById;
using Agriculture.Transactions.Application.Features.Clients.Queries.GetClients;
using Agriculture.Transactions.Contracts.Features.BuyOrders.Commands.CreateBuyOrder;
using Agriculture.Transactions.Contracts.Features.Clients.Commands.CreateClient;
using Agriculture.Transactions.Contracts.Features.Clients.Commands.DeleteClientById;
using Agriculture.Transactions.Contracts.Features.Clients.Queries.GetClientById;
using Agriculture.Transactions.Contracts.Features.Clients.Queries.GetClients;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Agriculture.Transactions.Web.Features.BuyOrders.Controller.v1
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/buy-orders")]
    [EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
    public class BuyOrdersController : ControllerBase
    {
        private readonly IAgricultureMapper _agricultureMapper;
        private readonly IAgricultureSender _agricultureSender;

        public BuyOrdersController(IAgricultureMapper agricultureMapper, IAgricultureSender agricultureSender)
        {
            _agricultureMapper = agricultureMapper;
            _agricultureSender = agricultureSender;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateBuyOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var createBuyOrderCommand = _agricultureMapper.Map<CreateBuyOrderCommand>(request);

            var createBuyOrderCommandResult = await _agricultureSender.SendAsync(createBuyOrderCommand, cancellationToken);

            var createBuyOrderCommandResponse = _agricultureMapper.Map<CreateBuyOrderCommandResponse>(createBuyOrderCommandResult);

            return Ok(createBuyOrderCommandResponse);
        }
        /*
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetBuyOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getBuyOrderByIdQuery = _agricultureMapper.Map<GetBuyOrderByIdQuery>(request);

            var getBuyOrderByIdQueryResult = await _agricultureSender.SendAsync(getBuyOrderByIdQuery, cancellationToken);

            var getBuyOrderByIdQueryResponse = _agricultureMapper.Map<GetBuyOrderByIdQueryResponse>(getBuyOrderByIdQueryResult);

            return Ok(getBuyOrderByIdQueryResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(GetBuyOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var getBuyOrdersQuery = _agricultureMapper.Map<GetBuyOrdersQuery>(request);

            var getBuyOrdersQueryResult = await _agricultureSender.SendAsync(getBuyOrdersQuery, cancellationToken);

            var getBuyOrdersQueryResponse = _agricultureMapper.Map<GetBuyOrdersQueryResponse>(getBuyOrdersQueryResult);

            return Ok(getBuyOrdersQueryResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync(DeleteBuyOrderByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteBuyOrderByIdCommand = _agricultureMapper.Map<DeleteBuyOrderByIdCommand>(request);

            await _agricultureSender.SendAsync(deleteBuyOrderByIdCommand, cancellationToken);

            return NoContent();
        }
        */
    }
}
