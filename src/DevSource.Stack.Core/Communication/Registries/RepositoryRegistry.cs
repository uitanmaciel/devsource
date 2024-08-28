using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication.Registries;

public static class RepositoryRegistry
{
    public static void Registry(IList<Type> types, IServiceCollection services)
    {
        var repositoryTypes = types
            .Where(type => !type.IsAbstract && RepositoryFilter(type))
            .ToList();

        foreach (var repository in repositoryTypes)
        {
            var repositoryInterfaces = repository.GetInterfaces();
            foreach(var repositoryInterface in repositoryInterfaces)
                services.AddScoped(repositoryInterface, repository);
        }
    }

    private static bool RepositoryFilter(Type type)
        => type.GetInterfaces()
            .Any(i => 
                i.Name.Contains("Repository") &&
                i.IsInterface);
}