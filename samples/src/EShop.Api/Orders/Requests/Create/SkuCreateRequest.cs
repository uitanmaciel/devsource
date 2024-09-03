using DevSource.Stack.Web;
using EShop.Application.Orders.Commands.Create;

namespace EShop.Api.Orders.Requests.Create;

public record SkuCreateRequest() : IRequestToCommand<SkuCreateRequest, SkuCreateCommand>
{
    public string Value { get; init; } = null!;
    
    public SkuCreateRequest(string value) :this() => Value = value;
    public static SkuCreateCommand ToCommand(SkuCreateRequest? request)
        => request is null
            ? new SkuCreateCommand()
            : new SkuCreateCommand(request.Value);

    public static IList<SkuCreateCommand> ToCommand(IList<SkuCreateRequest> requests)
        =>  requests.Select(ToCommand)
                    .ToList();
}