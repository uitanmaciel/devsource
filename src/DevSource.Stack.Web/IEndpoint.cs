using Microsoft.AspNetCore.Routing;

namespace DevSource.Stack.Web;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}