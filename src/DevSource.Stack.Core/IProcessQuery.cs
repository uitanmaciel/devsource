namespace DevSource.Stack.Core;

public interface IProcessQuery
{
    T ProcessQuery<T>(IQuery<T> query);
    Task<T> ProcessQueryAsync<T>(IQuery<T> query, CancellationToken cancellationToken);
}