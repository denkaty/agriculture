namespace Agriculture.Shared.Application.Abstractions.Messaging
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : class;
    }
}
