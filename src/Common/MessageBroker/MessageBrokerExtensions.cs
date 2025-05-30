using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MessageBroker;

public static class MessageBrokerExtensions
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration, IEnumerable<Assembly> assemblies)
    {
        
        services.Configure<MessageBrokerSettings>(configuration.GetSection("MessageBroker"));
        services.AddSingleton(sp =>sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

        services.AddMassTransit(cfg =>
        {
            foreach (var assembly in assemblies)
            {
                cfg.AddConsumers(assembly);
            }
            cfg.SetKebabCaseEndpointNameFormatter();
            cfg.UsingRabbitMq((context, configurator) =>
            {
                var settings = context.GetRequiredService<IOptions<MessageBrokerSettings>>().Value;
                configurator.Host(new Uri(settings.Host), host =>
                {
                    host.Username(settings.UserName);
                    host.Password(settings.Password);
                });
                configurator.ConfigureEndpoints(context);
            });
            
        });

        services.AddScoped<IEventBus, EventBus>();
        return services;
    }
}