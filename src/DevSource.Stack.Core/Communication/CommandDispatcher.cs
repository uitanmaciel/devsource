using DevSource.Stack.Core.Application.Handlers.CommandHandlers;

namespace DevSource.Stack.Core.Communication;

public sealed class CommandDispatcher : Dispatcher
{
    public static void Dispatcher(dynamic obj, IServiceProvider provider)
        => InvokeHandlerMethod(obj, provider, typeof(ICommandHandler<>), "Handle");

    public static TResult Dispatcher<TResult>(dynamic obj, IServiceProvider provider)
        => (TResult)InvokeHandlerMethod(obj, provider, typeof(ICommandHandler<,>), "Handle");

    public static async Task DispatcherAsync(dynamic obj, IServiceProvider provider)
        => await (Task)InvokeHandlerMethod(obj, provider, typeof(ICommandHandlerAsync<>), "HandleAsync");

    public static async Task<TResult> DispatcherAsync<TResult>(dynamic obj, IServiceProvider provider)
        => await (Task<TResult>)InvokeHandlerMethod(obj, provider, typeof(ICommandHandlerAsync<,>), "HandleAsync");
}