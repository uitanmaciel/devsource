using DevSource.Stack.Core;
using EShop.Domain.Aggregates.Orders.Enums;

namespace EShop.Application.Orders.Commands.Create;

public record OrderCreateCommand() : ICommand, ICommandToDomain<OrderCreateCommand, Order>
{
    public Guid CustomerId { get; init; }
    public OrderStatusCommand Status { get; init; }
    public IList<OrderItemCreateCommand> OrderItems { get; init; } = [];

    public OrderCreateCommand(
        Guid customerId,
        OrderStatusCommand status,
        IList<OrderItemCreateCommand> orderItems) : this()
    {
        CustomerId = customerId;
        Status = status;
        OrderItems = orderItems;
    }
    
    public Order ToDomain(OrderCreateCommand? command)
        => command is null
            ? new Order()
            : new Order(
                Guid.Empty,
                command.CustomerId,
                (OrderStatus)command.Status,
                command.OrderItems.Select(x => x.ToDomain(x))
                                  .ToList());

    public IList<Order> ToDomain(IList<OrderCreateCommand> command)
        => command.Select(ToDomain)
                  .ToList();
}