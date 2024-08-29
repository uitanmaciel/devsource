using DevSource.Stack.Core.Communication;
using DevSource.Stack.Core.Internal;

namespace DevSource.Stack.Core.Application.Handlers.CommandHandlers;

/// <summary>
/// Abstract base class for handling commands of type <typeparamref name="TCommand"/> with a state of type <typeparamref name="TState"/>.
/// Implements the <see cref="ICommandHandler{TCommand}"/> interface and includes transaction handling capabilities through the <see cref="IsCommandHandlerWithTransaction"/> interface.
/// </summary>
/// <typeparam name="TCommand">The type of command to handle. Must implement the <see cref="ICommand"/> interface.</typeparam>
/// <typeparam name="TResult">The type result of command to handle.</typeparam>
/// <typeparam name="TState">The type of state associated with the handler. Must implement the <see cref="IState"/> interface.</typeparam>
/// <typeparam name="TExtension">The type of extension associated with the handler. Must implement the <see cref="IState"/> interface.</typeparam>
public abstract class CommandHandlerWithExtensions<TCommand, TResult, TState, TExtension> :
    BaseCommandHandler,
    ICommandHandler<TCommand, TResult>,
    IProcessEvent
    where TCommand : ICommand
    where TState : IState
    where TExtension : IExtensions
{
    private readonly IDevSourceProperties _services = null!;
    private readonly IMediator _mediator;
    protected TState State { get; }
    protected TExtension Extension { get; }

    protected CommandHandlerWithExtensions(TState state, TExtension extension)
    {
        State = state ?? throw new ArgumentNullException(nameof(state));
        Extension = extension ?? throw new ArgumentNullException(nameof(extension));
        var mediatorFactory = new MediatorFactory();
        _mediator = mediatorFactory.CreateMediator(_services.Services);
    }
    
    protected CommandHandlerWithExtensions(TState state, TExtension extension, ITransactionFactory transactionFactory) : base(transactionFactory)
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
    public abstract TResult Handle(TCommand command);
    
    /// <summary>
    /// Processes a event by dispatching it through the mediator.
    /// </summary>
    /// <param name="event">The event to be processed.</param>
    public void ProcessEvent(object @event)
        => _mediator.Dispatcher(@event);
    
    /// <summary>
    /// Processes a event by dispatching it through the mediator and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result produced by dispatching the domain event.</typeparam>
    /// <param name="event">The event to be processed.</param>
    /// <returns>The result of type <typeparamref name="TResult"/> produced by dispatching the domain event.</returns>
    public TResult ProcessEvent<TResult>(object @event)
        => _mediator.Dispatcher<TResult>(@event);
}