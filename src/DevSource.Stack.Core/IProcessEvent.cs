namespace DevSource.Stack.Core;

public interface IProcessEvent
{
    /// <summary>
    /// Processes the given event by dispatching it through the mediator and adds it to the list of domain events.
    /// </summary>
    /// <param name="event">The event to be processed and stored. Must be castable to <see cref="DomainEvent"/>.</param>
    void ProcessEvent(object @event);
    
    /// <summary>
    /// Processes the given event by dispatching it through the mediator, stores the event in the domain events list, 
    /// and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of result expected from processing the event.</typeparam>
    /// <param name="event">The event to be processed and stored. Must be castable to <see cref="DomainEvent"/>.</param>
    /// <returns>The result of type <typeparamref name="TResult"/> obtained from processing the event.</returns>
    TResult ProcessEvent<TResult>(object @event);
}