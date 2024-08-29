using DevSource.Stack.Core.Communication;
using DevSource.Stack.Core.Internal;
using DevSource.Stack.Notifications;

namespace DevSource.Stack.Core.Application;

public abstract class ApplicationServices :
    Notifier,
    IProcessCommand,
    IProcessQuery
{
    private readonly IDevSourceProperties _service = null!;
    private readonly IMediator _mediator;

    protected ApplicationServices()
    {
        var mediatorFactory = new MediatorFactory();
        _mediator = mediatorFactory.CreateMediator(_service.Services);
    }
    
    /// <summary>
    /// Processes the given command by dispatching it through the mediator.
    /// </summary>
    /// <param name="command">The command to be processed. Must implement the <see cref="ICommand"/> interface.</param>
    public void ProcessCommand(ICommand command)
        => _mediator.Dispatcher(command);
    
    /// <summary>
    /// Processes the given command by dispatching it through the mediator and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of result expected from processing the command.</typeparam>
    /// <param name="command">The command to be processed. Must implement the <see cref="ICommand"/> interface.</param>
    /// <returns>The result of type <typeparamref name="TResult"/> obtained from processing the command.</returns>
    public TResult ProcessCommand<TResult>(ICommand command)
        => _mediator.Dispatcher<TResult>(command);
    
    /// <summary>
    /// Asynchronously processes the given command by dispatching it through the mediator.
    /// </summary>
    /// <param name="command">The command to be processed. Must implement the <see cref="ICommand"/> interface.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ProcessCommandAsync(ICommand command, CancellationToken cancellationToken)
        => await _mediator.DispatcherAsync(command);
    
    /// <summary>
    /// Asynchronously processes the given command by dispatching it through the mediator and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of result expected from processing the command.</typeparam>
    /// <param name="command">The command to be processed. Must implement the <see cref="ICommand"/> interface.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of type <typeparamref name="TResult"/>.</returns>
    public async Task<TResult> ProcessCommandAsync<TResult>(ICommand command, CancellationToken cancellationToken)
        => await _mediator.DispatcherAsync<TResult>(command);
    
    /// <summary>
    /// Processes the given query by dispatching it through the mediator and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of result expected from processing the query.</typeparam>
    /// <param name="query">The query to be processed. Must implement the <see cref="IQuery{TResult}"/> interface.</param>
    /// <returns>The result of type <typeparamref name="TResult"/> obtained from processing the query.</returns>
    public TResult ProcessQuery<TResult>(IQuery<TResult> query)
        => _mediator.Dispatcher<TResult>(query);
    
    /// <summary>
    /// Asynchronously processes the given query by dispatching it through the mediator and returns a result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of result expected from processing the query.</typeparam>
    /// <param name="query">The query to be processed. Must implement the <see cref="IQuery{TResult}"/> interface.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The result of type <typeparamref name="TResult"/> obtained from processing the query.</returns>
    public async Task<TResult> ProcessQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        => await _mediator.DispatcherAsync<TResult>(query);
}