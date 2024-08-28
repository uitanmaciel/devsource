namespace DevSource.Stack.Core;

public interface ITransaction
{
    Task<bool> ExecuteTransaction(Func<Task<bool>> action);
}