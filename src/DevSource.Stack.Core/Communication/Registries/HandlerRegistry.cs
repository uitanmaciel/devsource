using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication.Registries;

public static class HandlerRegistry
{
    public static void Registry(IList<Type> types, IServiceCollection serviceCollection)
    {
        var handlerTypes = types
            .Where(type => !type.IsAbstract && HandlerFilter(type))
            .ToList();
        
        foreach (var handler in handlerTypes)
        {   
            var handlerInterfaces = handler.GetInterfaces();
            foreach (var handlerInterface in handlerInterfaces)
            {
                if (handlerInterface.Name.Contains("CommandHandler") && handler is { IsClass: true, IsAbstract: false })
                    serviceCollection.AddScoped(handlerInterface, handler);
                else if (handlerInterface.Name.Contains("QueryHandler") && handler is { IsClass: true, IsAbstract: false })
                    serviceCollection.AddScoped(handlerInterface, handler);
                else if (handlerInterface.Name.Contains("EventHandler") && handler is { IsClass: true, IsAbstract: false })
                    serviceCollection.AddScoped(handlerInterface, handler);
            }
        }
    }
    
    private static bool HandlerFilter(Type type)
        => type is { IsClass: true, IsAbstract: false } &&
           type.GetInterfaces()
               .Any(i => i.IsGenericType && 
                         (i.Name.Contains("CommandHandler") ||
                          i.Name.Contains("QueryHandler") ||
                          i.Name.Contains("EventHandler")));
}