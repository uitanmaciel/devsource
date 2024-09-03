using System.Text.Json.Serialization;
using DevSource.Stack.Web;
using EShop.Application.Orders.Commands.Create;

namespace EShop.Api.Orders.Requests.Create;

public record ProductCreateRequest() : IRequestToCommand<ProductCreateRequest, ProductCreateCommand>
{
    [JsonPropertyName("productId")]
    public Guid ProductId { get; init; }
    
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
    
    [JsonPropertyName("sku")]
    public SkuCreateRequest Sku { get; init; } = null!;

    public ProductCreateRequest(Guid id, string name, SkuCreateRequest sku) : this()
    {
        ProductId = id;
        Name = name;
        Sku = sku;
    }
    
    public static ProductCreateCommand ToCommand(ProductCreateRequest? request)
        => request is null
            ? new ProductCreateCommand()
            : new ProductCreateCommand(
                request.ProductId,
                request.Name,
                SkuCreateRequest.ToCommand(request.Sku));

    public static IList<ProductCreateCommand> ToCommand(IList<ProductCreateRequest> requests)
        => requests.Select(ToCommand)
                   .ToList();
}