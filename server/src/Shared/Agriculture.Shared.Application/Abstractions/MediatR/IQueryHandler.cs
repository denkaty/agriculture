using MediatR;

namespace Agriculture.Shared.Application.Abstractions.MediatR
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>;
}
