using ItemEvents;
using MassTransit;
using MessageBroker;

namespace ProductService;

public class ItemCreatedConsumer : Consumer<ItemCreatedEvent>
{
    public override Task Consume(ConsumeContext<ItemCreatedEvent> context)
    {
        var item = context.Message.Id;
        return Task.CompletedTask;
    }
}