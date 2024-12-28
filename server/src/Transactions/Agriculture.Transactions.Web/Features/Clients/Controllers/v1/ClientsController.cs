using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Web.Utilities;
using Agriculture.Transactions.Application.Features.Clients.Commands;
using Agriculture.Transactions.Contracts.Features.Clients.Commands;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Agriculture.Transactions.Web.Features.Clients.Controllers.v1
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/clients")]
    [EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
    public class ClientsController : ControllerBase
    {
        private readonly IAgricultureMapper _agricultureMapper;
        private readonly IAgricultureSender _agricultureSender;

        public ClientsController(IAgricultureMapper agricultureMapper, IAgricultureSender agricultureSender)
        {
            _agricultureMapper = agricultureMapper;
            _agricultureSender = agricultureSender;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateClientCommandRequest request, CancellationToken cancellationToken)
        {
            var createClientCommand = _agricultureMapper.Map<CreateClientCommand>(request);

            var createClientCommandResult = await _agricultureSender.SendAsync(createClientCommand, cancellationToken);

            var createClientCommandResponse = _agricultureMapper.Map<CreateClientCommandResponse>(createClientCommandResult);

            return Ok(createClientCommandResponse);
        }
        /*
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(GetClientByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getClientByIdQuery = _agricultureMapper.Map<GetClientByIdQuery>(request);

            var getClientByIdQueryResult = await _agricultureSender.SendAsync(getClientByIdQuery, cancellationToken);

            var getClientByIdQueryResponse = _agricultureMapper.Map<GetClientByIdQueryResponse>(getClientByIdQueryResult);

            return Ok(getClientByIdQueryResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(GetClientsQueryRequest request, CancellationToken cancellationToken)
        {
            var getClientsQuery = _agricultureMapper.Map<GetClientsQuery>(request);

            var getClientsQueryResult = await _agricultureSender.SendAsync(getClientsQuery, cancellationToken);

            var getClientsQueryResponse = _agricultureMapper.Map<GetClientsQueryResponse>(getClientsQueryResult);

            return Ok(getClientsQueryResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync(DeleteClientByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteClientByIdCommand = _agricultureMapper.Map<DeleteClientByIdCommand>(request);

            await _agricultureSender.SendAsync(deleteClientByIdCommand, cancellationToken);

            return NoContent();
        }
        */
    }
}
