using DevSource.Stack.Notifications;

namespace DevSource.Stack.Core.Application.Handlers.QueryHandlers;

/// <summary>
/// Abstract base class for asynchronously handling queries of type <typeparamref name="TQuery"/> and producing a result of type <typeparamref name="TResult"/>
/// with a state of type <typeparamref name="TState"/>.
/// Implements the <see cref="IQueryHandlerAsync{TQuery, TResult}"/> interface.
/// </summary>
/// <typeparam name="TQuery">The type of query to handle. Must implement the <see cref="IQuery"/> interface.</typeparam>
/// <typeparam name="TResult">The type of result produced by handling the query.</typeparam>
/// <typeparam name="TState">The type of state associated with the handler. Must implement the <see cref="IState"/> interface.</typeparam>
/// <param name="state">The state associated with the query handler.</param>
public abstract class QueryHandlerAsync<TQuery, TResult, TState>(TState state) :
    Notifier,
    IQueryHandlerAsync<TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TState : IState
{
    /// <summary>
    /// The state associated with the event handler.
    /// </summary>
    protected TState State { get; } = state;
    
    /// <summary>
    /// Abstract method to asynchronously handle a query of type <typeparamref name="TQuery"/> and return a result of type <typeparamref name="TResult"/>.
    /// This method needs to be implemented by derived classes to specify
    /// the logic for processing the given query and producing a result asynchronously.
    /// </summary>
    /// <param name="query">The query to be handled.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of handling the query.</returns>
    public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
}