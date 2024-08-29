namespace DevSource.Stack.Core;

public interface IProcessStateAsync
{
    Task ProcessStateAsync(object obj, CancellationToken cancellationToken);
    Task<TResult> ProcessStateAsync<TResult>(object obj, CancellationToken cancellationToken);
}