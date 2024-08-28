namespace DevSource.Stack.Core.Application.Handlers.QueryHandlers;

public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
}