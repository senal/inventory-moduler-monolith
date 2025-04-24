using MassTransit;

namespace MessageBroker;

public class ConsumerDefinitions<T> : ConsumerDefinition<IConsumer<T>> where T : class;