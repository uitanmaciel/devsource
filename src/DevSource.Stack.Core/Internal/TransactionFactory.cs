using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Internal;

public class TransactionFactory(IServiceProvider provider) : ITransactionFactory
{
    private readonly IServiceProvider _serviceProvider = provider ?? throw new ArgumentNullException(nameof(provider));
    
    public ITransaction CreateTransaction()
        => _serviceProvider.GetRequiredService<ITransaction>();
}