namespace DevSource.Stack.Core;

public interface IProcessEventAsync
{
    Task ProcessEventAsync(object @event, CancellationToken cancellationToken);
    Task<TResult> ProcessEventAsync<TResult>(object @event, CancellationToken cancellationToken);
}