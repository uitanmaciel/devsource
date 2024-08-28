using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication.Registries;

public static class StateRegistry
{
    public static void Registry(IList<Type> types, IServiceCollection services)
    {
        var stateTypes = types
            .Where(type => !type.IsAbstract && StateFilter(type))
            .ToList();

        foreach (var state in stateTypes)
        {
            var stateInterfaces = state.GetInterfaces();
            foreach (var stateInterface in stateInterfaces)
                services.AddScoped(stateInterface, state);
        }
    }

    private static bool StateFilter(Type type)
        => type.GetInterfaces()
            .Any(i => 
                i.Name.EndsWith("State") && i.IsInterface);
}