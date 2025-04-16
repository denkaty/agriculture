using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Transactions.Application.Features.SellOrders.Commands.CreateSellOrder;
using Agriculture.Transactions.Contracts.Features.SellOrders.Commands.CreateSellOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Transactions.Web.Features.SellOrders.Controller.v1
{
    [Route("api/v{apiVersion:apiVersion}/sell-orders")]
    [ApiController]
    public class SellOrdersController : ControllerBase
    {
        private readonly IAgricultureMapper _agricultureMapper;
        private readonly IAgricultureSender _agricultureSender;

        public SellOrdersController(IAgricultureMapper agricultureMapper, IAgricultureSender agricultureSender)
        {
            _agricultureMapper = agricultureMapper;
            _agricultureSender = agricultureSender;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateSellOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var createSellOrderCommand = _agricultureMapper.Map<CreateSellOrderCommand>(request);

            var createSellOrderCommandResult = await _agricultureSender.SendAsync(createSellOrderCommand, cancellationToken);

            var createSellOrderCommandResponse = _agricultureMapper.Map<CreateSellOrderCommandResponse>(createSellOrderCommandResult);

            return Ok(createSellOrderCommandResponse);
        }
        /*
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetSellOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getSellOrderByIdQuery = _agricultureMapper.Map<GetSellOrderByIdQuery>(request);

            var getSellOrderByIdQueryResult = await _agricultureSender.SendAsync(getSellOrderByIdQuery, cancellationToken);

            var getSellOrderByIdQueryResponse = _agricultureMapper.Map<GetSellOrderByIdQueryResponse>(getSellOrderByIdQueryResult);

            return Ok(getSellOrderByIdQueryResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(GetSellOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var getSellOrdersQuery = _agricultureMapper.Map<GetSellOrdersQuery>(request);

            var getSellOrdersQueryResult = await _agricultureSender.SendAsync(getSellOrdersQuery, cancellationToken);

            var getSellOrdersQueryResponse = _agricultureMapper.Map<GetSellOrdersQueryResponse>(getSellOrdersQueryResult);

            return Ok(getSellOrdersQueryResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync(DeleteSellOrderByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteSellOrderByIdCommand = _agricultureMapper.Map<DeleteSellOrderByIdCommand>(request);

            await _agricultureSender.SendAsync(deleteSellOrderByIdCommand, cancellationToken);

            return NoContent();
        }
        */
    }
}
