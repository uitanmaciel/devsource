using DevSource.Stack.Notifications;

namespace DevSource.Stack.Core.Application.Handlers.EventHandlers;

/// <summary>
/// Abstract base class for handling events of type <typeparamref name="TEvent"/> with a state of type
/// <typeparamref name="TState"/> and an extension of type <typeparamref name="TExtension"/>.
/// Implements the <see cref="IEventHandler{TEvent}"/> interface.
/// </summary>
/// <typeparam name="TEvent">The type of event to handle. Must implement the <see cref="IEvent"/> interface.</typeparam>
/// <typeparam name="TResult">The result associated with the handler <see cref="IEvent"/> interface.</typeparam>
/// <typeparam name="TState">The type of state associated with the handler. Must implement the <see cref="IState"/> interface.</typeparam>
/// <typeparam name="TExtension">The type of extension associated with the handler. Must implement the <see cref="IExtensions"/> interface.</typeparam>
/// <param name="state">The state associated with the event handler.</param>
/// <param name="extension">The extension associated with the event handler.</param>
public abstract class EventHandlerWithExtensions<TEvent, TResult, TState, TExtension>(TState state, TExtension extension) :
    Notifier,
    IEventHandler<TEvent, TResult>
    where TEvent : IEvent
    where TState : IState
    where TExtension : IExtensions
{
    /// <summary>
    /// The state associated with the event handler.
    /// </summary>
    protected TState State { get; } = state;
    
    /// <summary>
    /// The extension associated with the event handler.
    /// </summary>
    protected TExtension Extension { get; } = extension;
    
    /// <summary>
    /// Abstract method to handle an event of type <typeparamref name="TEvent"/> and return a result of type <typeparamref name="TResult"/>.
    /// This method needs to be implemented by derived classes to specify
    /// the logic for processing the given event and producing a result.
    /// </summary>
    /// <param name="event">The event to be handled.</param>
    /// <returns>The result of handling the event.</returns>
    public abstract TResult Handle(TEvent @event);
}