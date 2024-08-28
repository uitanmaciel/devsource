namespace DevSource.Stack.Core.Internal;

public interface ITransactionFactory
{
    ITransaction CreateTransaction();
}