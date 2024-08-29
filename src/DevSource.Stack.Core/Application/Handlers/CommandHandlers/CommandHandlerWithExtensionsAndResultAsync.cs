using DevSource.Stack.Core.Communication;
using DevSource.Stack.Core.Internal;

namespace DevSource.Stack.Core.Application.Handlers.CommandHandlers;

public abstract class CommandHandlerWithExtensionsAsync<TCommand, TResult, TState, TExtension> :
    BaseCommandHandler,
    ICommandHandlerAsync<TCommand, TResult>,
    IProcessEventAsync
    where TCommand : ICommand
    where TState : IState
{
    private readonly IDevSourceProperties _services = null!;
    private readonly IMediator _mediator;
    protected TState State { get; }
    protected TExtension Extension { get; }

    protected CommandHandlerWithExtensionsAsync(TState state, TExtension extension)
    {
        State = state ?? throw new ArgumentNullException(nameof(state));
        Extension = extension ?? throw new ArgumentNullException(nameof(extension));
        var mediatorFactory = new MediatorFactory();
        _mediator = mediatorFactory.CreateMediator(_services.Services);
    }
    
    protected CommandHandlerWithExtensionsAsync(TState state, TExtension extension, ITransactionFactory transactionFactory) : base(transactionFactory)
    {
        State = state ?? throw new ArgumentNullException(nameof(state));
        Extension = extension;
        var mediatorFactory = new MediatorFactory();
        _mediator = mediatorFactory.CreateMediator(_services.Services);
    }
    
    /// <summary>
    /// Abstract method to handle a command of type <typeparamref name="TCommand"/>.
    /// This method needs to be implemented by derived classes to specify
    /// the logic for processing the given command.
    /// </summary>
    /// <param name="command">The command to be handled.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    public abstract Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    
    /// <summary>
    /// Asynchronously processes an event by dispatching it through the mediator with a cancellation token.
    /// </summary>
    /// <param name="event">The event to be processed.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ProcessEventAsync(object @event, CancellationToken cancellationToken)
        => await _mediator.DispatcherAsync(@event);

    /// <summary>
    /// Asynchronously processes an event by dispatching it through the mediator with a cancellation token and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by dispatching the event.</typeparam>
    /// <param name="event">The event to be processed.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of type <typeparamref name="TResult"/> produced by dispatching the event.</returns>
    public async Task<TResult> ProcessEventAsync<TResult>(object @event, CancellationToken cancellationToken)
        => await _mediator.DispatcherAsync<TResult>(@event);
}