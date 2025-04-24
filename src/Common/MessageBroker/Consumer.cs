using MassTransit;

namespace MessageBroker;

public abstract class Consumer<T> : IConsumer<T> where T : class 
{
    public virtual Task Consume(ConsumeContext<T> context)
    {
        throw new NotImplementedException();
    }
}