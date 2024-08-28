namespace DevSource.Stack.Core;

public interface IProcessQuery
{
    TResult ProcessQuery<TResult>(IQuery<TResult> query);
    Task<TResult> ProcessQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken);
}