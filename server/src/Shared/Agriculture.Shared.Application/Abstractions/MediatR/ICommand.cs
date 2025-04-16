using MediatR;

namespace Agriculture.Shared.Application.Abstractions.MediatR
{
    public interface ICommand : IRequest { }

    public interface ICommand<TResponse> : IRequest<TResponse> { }
}
