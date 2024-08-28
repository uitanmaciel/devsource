using DevSource.Stack.Core.Communication;
using DevSource.Stack.Core.Internal;

namespace DevSource.Stack.Core.Application.Handlers.CommandHandlers;

/// <summary>
/// Abstract base class for asynchronously handling commands of type <typeparamref name="TCommand"/> with a state of type <typeparamref name="TState"/>.
/// Implements the <see cref="ICommandHandlerAsync{TCommand}"/> interface and includes transaction handling capabilities through the <see cref="IsCommandHandlerWithTransaction"/> interface.
/// </summary>
/// <typeparam name="TCommand">The type of command to handle. Must implement the <see cref="ICommand"/> interface.</typeparam>
/// <typeparam name="TResult">The type of result associated with the handler. Must implement the <see cref="IState"/> interface.</typeparam>
/// <typeparam name="TState">The type of state associated with the handler. Must implement the <see cref="IState"/> interface.</typeparam>
public abstract class CommandHandlerAsync<TCommand, TResult, TState> :
    BaseCommandHandler,
    ICommandHandlerAsync<TCommand, TResult>,
    IProcessEventAsync
    where TCommand : ICommand
    where TState : IState
{
    private readonly IDevSourceProperties _services = null!;
    private readonly IMediator _mediator;
    
    protected TState State { get; }
    
    protected CommandHandlerAsync(TState state)
    {
        State = state;
        var mediatorFactory = new MediatorFactory();
        _mediator = mediatorFactory.CreateMediator(_services.Services);
    }

    protected CommandHandlerAsync(TState state, ITransactionFactory transactionFactory) : base(transactionFactory)
    {
        State = state;
        var mediatorFactory = new MediatorFactory();
        _mediator = mediatorFactory.CreateMediator(_services.Services);
    }
    
    /// <summary>
    /// Abstract method to handle a command of type <typeparamref name="TCommand"/>
    /// and return a result of type <typeparamref name="TResult"/>.
    /// This method needs to be implemented by derived classes to specify
    /// the logic for processing the given command and producing a result.
    /// </summary>
    /// <param name="command">The command to be handled.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The result of handling the command.</returns>
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