using EShop.Domain.Aggregates.Orders.ValueObjects;

namespace EShop.Domain.Aggregates.Orders.Entities;

public sealed class Product() : Entity
{
    public string Name { get; init; } = null!;
    public Sku Sku { get; init; } = null!;

    public Product(Guid id, string name, Sku sku) : this()
    {
        Id = id;
        Name = name;
        Sku = sku;
    }
    
    private void ValidateFields()
    {
        AddNotifications(new ValidationRules<Product>()
            .MinLength(nameof(Name), Name, 3)
            .MaxLength(nameof(Name), Name, 50)
        );
        
        if(Sku.HasNotifications)
            AddNotifications(Sku.Notifications);
    }
}