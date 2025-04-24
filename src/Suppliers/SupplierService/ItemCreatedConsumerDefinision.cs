using MassTransit;

namespace SupplierService;

public class ItemCreatedConsumerDefinition : ConsumerDefinition<ItemCreatedConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<ItemCreatedConsumer> consumerConfigurator,
        IRegistrationContext context)
    {
        endpointConfigurator.ConcurrentMessageLimit = 1;
        endpointConfigurator.PrefetchCount = 1;
    }
}