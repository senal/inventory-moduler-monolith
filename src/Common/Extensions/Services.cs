using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Extensions;

public static class ServicesExtensions
{
    public static void AddServicesFrom(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services
            .Scan(scan =>
                scan
                    .FromAssemblies(assemblies)
                    .AddClasses(c => c.WithAttribute<TransientAttribute>()).AsImplementedInterfaces()
                    .WithTransientLifetime()
                    .AddClasses(c => c.WithAttribute<ScopedAttribute>()).AsImplementedInterfaces()
                    .WithScopedLifetime());
    }
}