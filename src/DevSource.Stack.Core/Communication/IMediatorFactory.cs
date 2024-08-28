using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Communication;

public interface IMediatorFactory
{
    IMediator CreateMediator(IServiceCollection serviceCollection);
}