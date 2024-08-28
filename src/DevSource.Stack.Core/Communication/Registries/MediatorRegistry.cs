using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication.Registries;

public static class MediatorRegistry
{
    public static void RegistryAssemblies(IServiceCollection serviceCollection)
    {
        var assemblies = GetAssemblyTypes();
        RepositoryRegistry.Registry(assemblies, serviceCollection);
        StateRegistry.Registry(assemblies, serviceCollection);
        ExtensionRegistry.Registry(assemblies, serviceCollection);
        HandlerRegistry.Registry(assemblies, serviceCollection);
        EventRegistry.Registry(assemblies, serviceCollection);
    }
    private static IList<Type> GetAssemblyTypes()
        => AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assemblies => assemblies.GetTypes())
            .ToList();
}