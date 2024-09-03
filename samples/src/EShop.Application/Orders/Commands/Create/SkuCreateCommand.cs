using DevSource.Stack.Core;
using EShop.Domain.Aggregates.Orders.ValueObjects;

namespace EShop.Application.Orders.Commands.Create;

public record SkuCreateCommand() : ICommand, ICommandToDomain<SkuCreateCommand, Sku>
{
    public string Value { get; init; } = null!;

    public SkuCreateCommand(string value) : this() => Value = value;
    
    public Sku ToDomain(SkuCreateCommand? command)
        => command is null
            ? new Sku()
            : new Sku(command.Value);

    public IList<Sku> ToDomain(IList<SkuCreateCommand> command)
        => command.Select(ToDomain)
                  .ToList();
}