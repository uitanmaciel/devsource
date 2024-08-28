using DevSource.Stack.Notifications;

namespace DevSource.Stack.Core.Application.Handlers.EventHandlers;

/// <summary>
/// Abstract base class for asynchronously handling events of type <typeparamref name="TEvent"/> with a state of type <typeparamref name="TState"/>.
/// Implements the <see cref="IEventHandlerAsync{TEvent}"/> interface.
/// </summary>
/// <typeparam name="TEvent">The type of event to handle. Must implement the <see cref="IEvent"/> interface.</typeparam>
/// <typeparam name="TState">The type of state associated with the handler. Must implement the <see cref="IState"/> interface.</typeparam>
/// <param name="state">The state associated with the event handler.</param>
public abstract class EventHandlerAsync<TEvent, TState>(TState state) : 
    Notifier,
    IEventHandlerAsync<TEvent>
    where TEvent : IEvent
    where TState : IState
{
    /// <summary>
    /// The state associated with the event handler.
    /// </summary>
    protected TState State { get; } = state;
    
    /// <summary>
    /// Abstract method to asynchronously handle an event of type <typeparamref name="TEvent"/> with a cancellation token.
    /// This method needs to be implemented by derived classes to specify
    /// the logic for processing the given event asynchronously.
    /// </summary>
    /// <param name="event">The event to be handled.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public abstract Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
}