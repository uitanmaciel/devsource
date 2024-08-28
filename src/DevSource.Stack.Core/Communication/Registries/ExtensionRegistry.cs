using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication.Registries;

public static class ExtensionRegistry
{
    public static void Registry(IList<Type> types, IServiceCollection services)
    {
        var extensionTypes = types
            .Where(type => !type.IsAbstract && ExtensionFilter(type))
            .ToList();

        foreach (var extension in extensionTypes)
        {
            var extensionInterfaces = extension.GetInterfaces();
            foreach(var extensionInterface in extensionInterfaces)
                services.AddScoped(extensionInterface, extension);
        }
    }

    private static bool ExtensionFilter(Type type)
        => type.GetInterfaces()
            .Any(i => 
                i.Name.Contains("Extensions") &&
                i.IsInterface);
}