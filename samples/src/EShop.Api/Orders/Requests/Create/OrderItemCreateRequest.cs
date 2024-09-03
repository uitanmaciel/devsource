using System.Text.Json.Serialization;
using DevSource.Stack.Web;
using EShop.Application.Orders.Commands.Create;

namespace EShop.Api.Orders.Requests.Create;

public record OrderItemCreateRequest() : IRequestToCommand<OrderItemCreateRequest, OrderItemCreateCommand>
{
    [JsonPropertyName("product")]
    public ProductCreateRequest Product { get; init; } = null!;
    
    [JsonPropertyName("quantity")]
    public double Quantity { get; init; }
    
    [JsonPropertyName("price")]
    public decimal Price { get; init; }

    public OrderItemCreateRequest(
        ProductCreateRequest product, 
        double quantity, 
        decimal price) : this()
    {
        Product = product;
        Quantity = quantity;
        Price = price;
    }
    
    public static OrderItemCreateCommand ToCommand(OrderItemCreateRequest? request)
        => request is null
            ? new OrderItemCreateCommand()
            : new OrderItemCreateCommand(
                ProductCreateRequest.ToCommand(request.Product),
                request.Quantity,
                request.Price);

    public static IList<OrderItemCreateCommand> ToCommand(IList<OrderItemCreateRequest> requests)
        => requests.Select(ToCommand)
                   .ToList();
}