using DevSource.Stack.Core;
using EShop.Domain.Aggregates.Orders.ValueObjects;

namespace EShop.Application.Orders.Commands.Create;

public record OrderItemCreateCommand() : ICommand, ICommandToDomain<OrderItemCreateCommand, OrderItem>
{
    public ProductCreateCommand Product { get; init; } = null!;
    public double Quantity { get; init; }
    public decimal Price { get; init; }

    public OrderItemCreateCommand(
        ProductCreateCommand product, 
        double quantity, 
        decimal price) : this()
    {
        Product = product;
        Quantity = quantity;
        Price = price;
    }
    
    public OrderItem ToDomain(OrderItemCreateCommand? command)
        => command is null
            ? new OrderItem()
            : new OrderItem(
                command.Product.ToDomain(command.Product),
                command.Quantity,
                command.Price);

    public IList<OrderItem> ToDomain(IList<OrderItemCreateCommand> command)
        => command.Select(ToDomain)
                  .ToList();
}