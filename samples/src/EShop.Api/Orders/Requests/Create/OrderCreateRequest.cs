using System.Text.Json.Serialization;
using DevSource.Stack.Web;
using EShop.Application.Orders.Commands;
using EShop.Application.Orders.Commands.Create;

namespace EShop.Api.Orders.Requests.Create;

public record OrderCreateRequest() : IRequestToCommand<OrderCreateRequest, OrderCreateCommand>
{
    [JsonPropertyName("customerId")]
    public Guid CustomerId { get; init; }
    
    [JsonPropertyName("orderStatus")]
    public OrderStatusRequest Status { get; init; }
    
    [JsonPropertyName("orderItems")]
    public IList<OrderItemCreateRequest> OrderItems { get; init; } = [];

    public static OrderCreateCommand ToCommand(OrderCreateRequest? request)
        => request is null
            ? new OrderCreateCommand()
            : new OrderCreateCommand(
                request.CustomerId,
                (OrderStatusCommand)request.Status,
                OrderItemCreateRequest.ToCommand(request.OrderItems));

    public static IList<OrderCreateCommand> ToCommand(IList<OrderCreateRequest> requests)
        => requests.Select(ToCommand)
                   .ToList();
}