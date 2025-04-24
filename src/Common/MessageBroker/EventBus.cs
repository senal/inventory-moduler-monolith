using MassTransit;

namespace MessageBroker;

public interface IEventBus
{
    Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class;
}

public sealed class EventBus(IPublishEndpoint publishEndpoint) : IEventBus
{
    public async Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class
    {
        ArgumentNullException.ThrowIfNull(@event);
        await publishEndpoint.Publish<T>(@event, cancellationToken);
    }
}