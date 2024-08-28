using DevSource.Stack.Core.Application.Handlers;
using DevSource.Stack.Core.Communication.Registries;
using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication;

public sealed class Mediator : IMediator
{
    private static IServiceProvider _serviceProvider = null!;

    public Mediator(IServiceCollection services)
    {
        MediatorRegistry.RegistryAssemblies(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    public void Dispatcher(dynamic obj, IServiceProvider provider = null!)
    {
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));
        var dispatch = GetObjectType(obj) switch
        {
            HandlerType.Command => CommandDispatcher.Dispatcher(obj, _serviceProvider),
            HandlerType.Query => QueryDispatcher.Dispatcher(obj, _serviceProvider),
            _ => EventDispatcher.Dispatcher(obj, _serviceProvider)
        };
    }

    public TResult Dispatcher<TResult>(dynamic obj, IServiceProvider provider)
    {
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));
        return GetObjectType(obj) switch
        {
            HandlerType.Command => CommandDispatcher.Dispatcher<TResult>(obj, _serviceProvider),
            HandlerType.Query => QueryDispatcher.Dispatcher<TResult>(obj, _serviceProvider),
            _ => EventDispatcher.Dispatcher<TResult>(obj, _serviceProvider)
        };
    }

    public async Task DispatcherAsync(dynamic obj, IServiceProvider provider)
    {
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));
        var dispatcherAsync = await GetObjectType(obj) switch
        {
            HandlerType.Command => CommandDispatcher.DispatcherAsync(obj, _serviceProvider),
            HandlerType.Query => QueryDispatcher.DispatcherAsync(obj, _serviceProvider),
            _ => EventDispatcher.DispatcherAsync(obj, _serviceProvider)
        };
    }

    public async Task<TResult> DispatcherAsync<TResult>(dynamic obj, IServiceProvider provider)
    {
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));
        return await GetObjectType(obj) switch
        {
            HandlerType.Command => CommandDispatcher.DispatcherAsync<TResult>(obj, _serviceProvider),
            HandlerType.Query => QueryDispatcher.DispatcherAsync<TResult>(obj, _serviceProvider),
            _ => EventDispatcher.DispatcherAsync<TResult>(obj, _serviceProvider)
        };
    }
    
    private static HandlerType? GetObjectType(dynamic obj)
    {
        var objType = obj.GetType();
        var objInterfaces = objType.GetInterfaces();
        HandlerType? handlerType = null;
        foreach(var objInterface in objInterfaces)
        {
            if (objInterface.Name.Contains("Command"))
                handlerType = HandlerType.Command;

            if (objInterface.Name.Contains("Query"))
                handlerType = HandlerType.Query;

            if (objInterface.Name.Contains("Event"))
                handlerType = HandlerType.Event;
        }

        return handlerType;
    }
}