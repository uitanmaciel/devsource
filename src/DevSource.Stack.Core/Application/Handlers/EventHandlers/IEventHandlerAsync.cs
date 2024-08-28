namespace DevSource.Stack.Core.Application.Handlers.EventHandlers;

public interface IEventHandlerAsync<in TEvent>
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
}

public interface IEventHandlerAsync<in TEvent, TResult>
{
    Task<TResult> HandleAsync(TEvent @event, CancellationToken cancellationToken);
}