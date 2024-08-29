using DevSource.Stack.Core.Communication;
using DevSource.Stack.Core.Internal;

namespace DevSource.Stack.Core.Domain;

public abstract class AggregateRoot<TId> : 
    Entity, 
    IProcessEvent, 
    IProcessEventAsync
    where TId : notnull
{
    private readonly IDevSourceProperties _service = null!;
    private readonly IMediator _mediator;
    private readonly IList<DomainEvent> _domainEvents = [];
    private int Version { get; set; } = -1;

    protected AggregateRoot()
    {
        var mediatorFactory = new MediatorFactory();
        _mediator = mediatorFactory.CreateMediator(_service.Services);
    }

    protected AggregateRoot(TId id) : base(id!)
    {
        var mediatorFactory = new MediatorFactory();
        _mediator = mediatorFactory.CreateMediator(_service.Services);
    }
    
    /// <summary>
    /// Retrieves a read-only collection of domain events accumulated in the current context.
    /// </summary>
    /// <returns>An enumerable collection of <see cref="DomainEvent"/> that are read-only.</returns>
    public IEnumerable<DomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();
    
    /// <summary>
    /// Clears all domain events from the list, marking them as committed.
    /// </summary>
    public void MarkEventsAsCommitted() => _domainEvents.Clear();
    
    /// <summary>
    /// Loads domain events from a given history into the aggregate's event list and increments the version
    /// for each event loaded.
    /// </summary>
    /// <param name="history">An enumerable collection of domain events representing the historical
    /// events to be loaded.</param>
    public void LoadFromHistory(IEnumerable<DomainEvent> history)
    {
        foreach (var e in history)
        {
            _domainEvents.Add(e);
            Version++;
        }
    }
    
    /// <summary>
    /// Processes the given event by dispatching it through the mediator and adds it to the list of domain events.
    /// </summary>
    /// <param name="event">The event to be processed and stored. Must be castable to <see cref="DomainEvent"/>.</param>
    public void ProcessEvent(object @event)
    {
        _mediator.Dispatcher(@event);
        _domainEvents.Add((DomainEvent)@event);
    }
    
    /// <summary>
    /// Processes the given event by dispatching it through the mediator, stores the event in the domain events list, 
    /// and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of result expected from processing the event.</typeparam>
    /// <param name="event">The event to be processed and stored. Must be castable to <see cref="DomainEvent"/>.</param>
    /// <returns>The result of type <typeparamref name="TResult"/> obtained from processing the event.</returns>
    public TResult ProcessEvent<TResult>(object @event)
    {
        var result = _mediator.Dispatcher<TResult>(@event);
        _domainEvents.Add((DomainEvent)@event);
        return result;
    }
    
    /// <summary>
    /// Asynchronously processes the given event by dispatching it through the mediator, and adds it to the list of domain events.
    /// </summary>
    /// <param name="event">The event to be processed and stored. Must be castable to <see cref="DomainEvent"/>.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ProcessEventAsync(object @event, CancellationToken cancellationToken)
    {
        await _mediator.DispatcherAsync(@event);
        _domainEvents.Add((DomainEvent)@event);
    }
    
    /// <summary>
    /// Asynchronously processes the given event by dispatching it through the mediator, stores the event in the domain events list,
    /// and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of result expected from processing the event.</typeparam>
    /// <param name="event">The event to be processed and stored. Must be castable to <see cref="DomainEvent"/>.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of type
    /// <typeparamref name="TResult"/> obtained from processing the event.</returns>
    public async Task<TResult> ProcessEventAsync<TResult>(object @event, CancellationToken cancellationToken)
    {
        var result = await _mediator.DispatcherAsync<TResult>(@event);
        _domainEvents.Add((DomainEvent)@event);
        return result;
    }
}