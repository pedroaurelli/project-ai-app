using Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Reflection;

namespace Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var types = assembly.GetTypes()
            .Where(type => !type.IsAbstract)
            .Where(type => type.IsClass)
            .Where(type => type.Name.EndsWith("Service"));

        foreach (var type in types)
        {
            if (type.IsSubclassOf(typeof(Service)))
            {
                services.AddScoped(type, provider => GetServiceInstance(type, provider));
            }
            else
            {
                services.AddScoped(type);
            }
        }

        return services;
    }

    private static object GetServiceInstance(
        Type serviceType, IServiceProvider provider)
    {
        var parameterInfos = serviceType.GetConstructors().FirstOrDefault()?.GetParameters();
        var parameters = parameterInfos?
            .Select(parameterInfo => provider.GetRequiredService(parameterInfo.ParameterType))
            .ToArray();
        var instance = Activator.CreateInstance(serviceType, parameters)!;

        var bindingFlags =
            BindingFlags.NonPublic |
            BindingFlags.Instance;

        if (instance is Service service)
        {
            var dbContext = provider.GetRequiredService<DatabaseContext>();
            var dbContextField = typeof(Service).GetField("<DbContext>k__BackingField", bindingFlags)!;
            dbContextField.SetValue(instance, dbContext);

            var logger = provider.GetService<ILoggerFactory>()?.CreateLogger(serviceType)
                ?? NullLogger.Instance;
            var loggerField = typeof(Service).GetField("<Logger>k__BackingField", bindingFlags)!;
            loggerField.SetValue(instance, logger);
        }

        return instance;
    }
}
