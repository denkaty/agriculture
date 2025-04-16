using MediatR;

namespace Agriculture.Shared.Application.Abstractions.MediatR
{
    public interface IQuery<TResponse> : IRequest<TResponse>;
}
