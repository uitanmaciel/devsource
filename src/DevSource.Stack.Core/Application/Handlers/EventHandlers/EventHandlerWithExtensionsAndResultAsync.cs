﻿using DevSource.Stack.Notifications;

namespace DevSource.Stack.Core.Application.Handlers.EventHandlers;

/// <summary>
/// Abstract base class for asynchronously handling events of type <typeparamref name="TEvent"/> with a state of type <typeparamref name="TState"/>, 
/// an extension of type <typeparamref name="TExtension"/>, and returning a result of type <typeparamref name="TResult"/>.
/// Implements the <see cref="IEventHandlerAsync{TEvent, TResult}"/> interface.
/// </summary>
/// <typeparam name="TEvent">The type of event to handle. Must implement the <see cref="IEvent"/> interface.</typeparam>
/// <typeparam name="TResult">The type of result returned by the event handler.</typeparam>
/// <typeparam name="TState">The type of state associated with the handler. Must implement the <see cref="IState"/> interface.</typeparam>
/// <typeparam name="TExtension">The type of extension associated with the handler. Must implement the <see cref="IExtension"/> interface.</typeparam>
/// <param name="state">The state associated with the event handler.</param>
/// <param name="extension">The extension associated with the event handler.</param>
public abstract class EventHandlerWithExtensionsAsync<TEvent, TResult, TState, TExtension>(TState state, TExtension extension) :
    Notifier,
    IEventHandlerAsync<TEvent, TResult>
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
    /// Abstract method to asynchronously handle an event of type <typeparamref name="TEvent"/> and return
    /// a result of type <typeparamref name="TResult"/> with a cancellation token.
    /// This method needs to be implemented by derived classes to specify
    /// the logic for processing the given event asynchronously and producing a result.
    /// </summary>
    /// <param name="event">The event to be handled.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of handling the event.</returns>
    public abstract Task<TResult> HandleAsync(TEvent @event, CancellationToken cancellationToken);
}