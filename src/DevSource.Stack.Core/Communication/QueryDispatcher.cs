using DevSource.Stack.Core.Application.Handlers.QueryHandlers;

namespace DevSource.Stack.Core.Communication;

public sealed class QueryDispatcher : Dispatcher
{
    public static void Dispatcher(dynamic obj, IServiceProvider provider)
    {
        throw new NotImplementedException();
    }

    public static TResult Dispatcher<TResult>(dynamic obj, IServiceProvider provider)
        => (TResult)InvokeHandlerMethod(obj, provider, typeof(IQueryHandler<,>), "Handle");

    public static Task DispatcherAsync(dynamic obj, IServiceProvider provider)
    {
        throw new NotImplementedException();
    }

    public static async Task<TResult> DispatcherAsync<TResult>(dynamic obj, IServiceProvider provider)
        => await (Task<TResult>)InvokeHandlerMethod(obj, provider, typeof(IQueryHandlerAsync<,>), "HandleAsync");
}