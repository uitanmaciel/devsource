namespace EShop.Domain.Aggregates.Orders.ValueObjects;

public class Sku() : ValueObject
{
    public string Value { get; init; } = null!;

    public Sku(string value) : this()
    {
        Value = value;
        ValidateFields();
    }

    private void ValidateFields()
    {
        AddNotifications(new ValidationRules<Sku>()
            .MinLength("Sku", Value, 15)
            .MaxLength("Sku", Value, 15)
        );
    }
}