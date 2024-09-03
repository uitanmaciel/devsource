using EShop.Domain.Aggregates.Orders.Entities;

namespace EShop.Domain.Aggregates.Orders.ValueObjects;

public sealed class OrderItem() : ValueObject
{
    public Product Product { get; init; } = null!;
    public double Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal Total => (decimal)Quantity * Price;

    public OrderItem(Product product, double quantity,decimal price) : this()
    {
        Product = product;
        Quantity = quantity;
        Price = price;
        ValidateFields();
    }
    
    private void ValidateFields()
    {
        AddNotifications(new ValidationRules<OrderItem>()
            .IsGreaterThan(nameof(Quantity), Quantity, 0D)
            .IsGreaterThan(nameof(Price), Price, 0.00M)
        );
    }
}