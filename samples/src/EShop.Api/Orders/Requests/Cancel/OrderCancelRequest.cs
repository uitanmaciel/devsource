using System.Text.Json.Serialization;
using DevSource.Stack.Web;
using EShop.Application.Orders.Commands;
using EShop.Application.Orders.Commands.Cancel;

namespace EShop.Api.Orders.Requests.Cancel;

public record OrderCancelRequest() : IRequestToCommand<OrderCancelRequest, OrderCancelCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    
    [JsonPropertyName("status")]
    public OrderStatusRequest Status { get; init; }

    public OrderCancelRequest(Guid id, OrderStatusRequest status) : this()
    {
        Id = id;
        Status = status;
    }
    
    public static OrderCancelCommand ToCommand(OrderCancelRequest? request)
        => request is null
            ? new OrderCancelCommand()
            : new OrderCancelCommand(
                request.Id, 
                (OrderStatusCommand)(request.Status));

    public static IList<OrderCancelCommand> ToCommand(IList<OrderCancelRequest> requests)
        => requests.Select(ToCommand)
                   .ToList();
}