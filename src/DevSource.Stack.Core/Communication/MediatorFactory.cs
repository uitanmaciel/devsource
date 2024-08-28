using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication;

public sealed class MediatorFactory : IMediatorFactory
{
    public IMediator CreateMediator(IServiceCollection serviceCollection)
        => new Mediator(serviceCollection);
}