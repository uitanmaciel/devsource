using DevSource.Stack.Core;
using EShop.Domain.Aggregates.Orders.Entities;

namespace EShop.Application.Orders.Commands.Create;

public record ProductCreateCommand() : ICommand, ICommandToDomain<ProductCreateCommand, Product>
{
    public Guid ProductId { get; init; }
    public string Name { get; init; } = null!;
    public SkuCreateCommand Sku { get; init; } = null!;

    public ProductCreateCommand(Guid id, string name, SkuCreateCommand sku) : this()
    {
        ProductId = id;
        Name = name;
        Sku = sku;
    }
    
    public Product ToDomain(ProductCreateCommand? command)
        => command is null
            ? new Product()
            : new Product(
                command.ProductId,
                command.Name,
                command.Sku.ToDomain(command.Sku));

    public IList<Product> ToDomain(IList<ProductCreateCommand> command)
        => command.Select(ToDomain)
                  .ToList();
}