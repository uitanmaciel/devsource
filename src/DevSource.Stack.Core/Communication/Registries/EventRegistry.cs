using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication.Registries;

public static class EventRegistry
{
    public static void Registry(IList<Type> types, IServiceCollection services)
    {
        var eventTypes = types
            .Where(type => !type.IsAbstract && EventFilter(type))
            .ToList();

        foreach (var @event in eventTypes)
        {
            var eventInterfaces = @event.GetInterfaces();
            foreach(var eventInterface in eventInterfaces)
                services.AddScoped(eventInterface, @event);
        }
    }

    private static bool EventFilter(Type type)
        => type.GetInterfaces()
            .Any(i => 
                i.Name.Contains("DomainEvent") ||
                (i.Name.Contains("EventHandler") && i.IsInterface));
}