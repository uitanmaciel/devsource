using DevSource.Stack.Core.Communication;
using DevSource.Stack.Core.Internal;

namespace DevSource.Stack.Core.Application.Handlers.CommandHandlers;

public abstract class CommandHandler<TCommand, TState, TResult> :
    BaseCommandHandler,
    ICommandHandler<TCommand, TResult>,
    IProcessEvent
    where TCommand : ICommand
    where TState : IState
{
    private readonly IDevSourceProperties _services = null!;
    private readonly IMediator _mediator;
    protected TState State { get; }
    
    protected CommandHandler(TState state)
    {
        State = state;
        var mediatorFactory = new MediatorFactory();
        _mediator = mediatorFactory.CreateMediator(_services.Services);
    }

    protected CommandHandler(TState state, ITransactionFactory transactionFactory) : base(transactionFactory)
    {
        State = state;
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