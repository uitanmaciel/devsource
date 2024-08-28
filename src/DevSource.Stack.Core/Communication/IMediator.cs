using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication;

public interface IMediator
{
    static IServiceCollection ServiceCollection { get; } = null!;
    void Dispatcher(dynamic obj, IServiceProvider provider = null!);
    TResult Dispatcher<TResult>(dynamic obj, IServiceProvider provider = null!);
    Task DispatcherAsync(dynamic obj, IServiceProvider provider = null!);
    Task<TResult> DispatcherAsync<TResult>(dynamic obj, IServiceProvider provider = null!);
}