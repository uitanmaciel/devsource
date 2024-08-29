namespace DevSource.Stack.Core;

public interface IProcessEventAsync
{
    /// <summary>
    /// Asynchronously processes the given event by dispatching it through the mediator, and adds it to the list of domain events.
    /// </summary>
    /// <param name="event">The event to be processed and stored. Must be castable to <see cref="DomainEvent"/>.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ProcessEventAsync(object @event, CancellationToken cancellationToken);
    
    /// <summary>
    /// Asynchronously processes the given event by dispatching it through the mediator, stores the event in the domain events list,
    /// and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of result expected from processing the event.</typeparam>
    /// <param name="event">The event to be processed and stored. Must be castable to <see cref="DomainEvent"/>.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of type
    /// <typeparamref name="TResult"/> obtained from processing the event.</returns>
    Task<TResult> ProcessEventAsync<TResult>(object @event, CancellationToken cancellationToken);
}