using DevSource.Stack.Core.Application.Handlers.EventHandlers;

namespace DevSource.Stack.Core.Communication;

public sealed class EventDispatcher : Dispatcher
{
    public static void Dispatcher(dynamic obj, IServiceProvider provider)
        => InvokeHandlerMethod(obj, provider, typeof(IEventHandler<>), "Handle");
    
    public static TResult Dispatcher<TResult>(dynamic obj, IServiceProvider provider)
        => (TResult)InvokeHandlerMethod(obj, provider, typeof(IEventHandler<,>), "Handle");
    
    public static Task DispatcherAsync(dynamic obj, IServiceProvider provider)
        => (Task)InvokeHandlerMethod(obj, provider, typeof(IEventHandlerAsync<>), "HandleAsync");
    
    public static Task<TResult> DispatcherAsync<TResult>(dynamic obj, IServiceProvider provider)
        => (Task<TResult>)InvokeHandlerMethod(obj, provider, typeof(IEventHandlerAsync<,>), "HandleAsync");
}