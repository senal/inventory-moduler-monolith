using MassTransit;

namespace MessageBroker;

public abstract class Consumer<T> : IConsumer<T> where T : class
{
    public abstract Task Consume(ConsumeContext<T> context);

}