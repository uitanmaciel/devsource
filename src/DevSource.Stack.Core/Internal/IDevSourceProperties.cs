using Microsoft.Extensions.DependencyInjection;

namespace DevSource.Stack.Core.Internal;

public interface IDevSourceProperties
{
    IServiceCollection Services { get; set; }
}