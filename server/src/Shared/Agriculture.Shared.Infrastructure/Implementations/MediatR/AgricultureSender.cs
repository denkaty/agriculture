using Agriculture.Shared.Application.Abstractions.MediatR;
using MediatR;

namespace Agriculture.Shared.Infrastructure.Implementations.MediatR
{
    public class AgricultureSender : IAgricultureSender
    {
        private readonly ISender _sender;

        public AgricultureSender(ISender sender)
        {
            _sender = sender;
        }

        public async Task SendAsync<TRequest>(TRequest request, CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await _sender.Send(request, cancellationToken);
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(request, cancellationToken);

            return response;
        }
    }
}
