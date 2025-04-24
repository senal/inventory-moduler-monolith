namespace MessageBroker;

public interface IEventBus
{
    Task PublishAsync<T>(T @event);
}

public sealed class EventBus : IEventBus
{
    public Task PublishAsync<T>(T @event)
    {
        throw new NotImplementedException();
    }
}