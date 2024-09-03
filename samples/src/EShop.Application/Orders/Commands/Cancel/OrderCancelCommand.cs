using DevSource.Stack.Core;
using EShop.Domain.Aggregates.Orders.Enums;

namespace EShop.Application.Orders.Commands.Cancel;

public record OrderCancelCommand() : ICommand, ICommandToDomain<OrderCancelCommand, Order>
{
    public Guid Id { get; init; }
    public OrderStatusCommand Status { get; init; }

    public OrderCancelCommand(Guid id, OrderStatusCommand status) : this()
    {
        Id = id;
        Status = status;
    }
    
    public Order ToDomain(OrderCancelCommand? command)
        => command is null
            ? new Order()
            : new Order(
                command.Id, 
                Guid.Empty, 
                (OrderStatus)command.Status, 
                []);

    public IList<Order> ToDomain(IList<OrderCancelCommand> command)
        => command.Select(ToDomain).ToList();
}