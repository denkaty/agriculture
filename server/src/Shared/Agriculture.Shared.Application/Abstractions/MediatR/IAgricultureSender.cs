using MediatR;

namespace Agriculture.Shared.Application.Abstractions.MediatR
{
    public interface IAgricultureSender
    {
        Task SendAsync<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest;

        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
    }
}
