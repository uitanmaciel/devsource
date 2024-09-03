using DevSource.Stack.Core.Internal;
using DevSource.Stack.Notifications;

namespace DevSource.Stack.Core.Application.Handlers.CommandHandlers;

public abstract class BaseCommandHandler() : Notifier, ITransaction
{
    private readonly ITransaction _transaction = null!;
    
    protected BaseCommandHandler(ITransactionFactory transactionFactory) : this()
    {
        _transaction = transactionFactory.CreateTransaction();
    }

    public async Task<bool> ExecuteTransaction(Func<Task<bool>> action)
        => await _transaction.ExecuteTransaction(action);
}