using System.Reflection;
using DevSource.Stack.Notifications;

namespace DevSource.Stack.Core.Domain;

public abstract class ValueObject : Notifier, IEquatable<ValueObject>
{
    /// <summary>
    /// Gets the components that contribute to the equality comparison.
    /// </summary>
    /// <returns>An IEnumerable of objects representing the equality components.</returns>
    protected virtual IEnumerable<object> GetEqualityComponents()
    {
        return GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(p => p.GetValue(this))!;
    }

    /// <summary>
    /// Determines whether the current value object is equal to another value object.
    /// </summary>
    /// <param name="other">The value object to compare.</param>
    /// <returns>True if the value objects are equal; otherwise, false.</returns>
    public bool Equals(ValueObject? other)
        => other is not null && GetType() == other.GetType() && ValuesAreEqual(other);

    /// <summary>
    /// Determines whether the current value object is equal to an object.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>True if the object is a value object and is equal; otherwise, false.</returns>
    public override bool Equals(object? obj)
        => obj is ValueObject valueObject && Equals(valueObject);

    /// <summary>
    /// Checks if the values of two value objects are equal.
    /// </summary>
    /// <param name="other">The other value object to compare.</param>
    /// <returns>True if the values are equal; otherwise, false.</returns>
    private bool ValuesAreEqual(ValueObject? other)
        => other is not null && GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());

    /// <summary>
    /// Implements the equality operator for value objects.
    /// </summary>
    /// <param name="a">The first value object.</param>
    /// <param name="b">The second value object.</param>
    /// <returns>True if the value objects are equal; otherwise, false.</returns>
    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null ^ b is null)
            return false;

        return a?.Equals(b) != false;
    }

    /// <summary>
    /// Implements the inequality operator for value objects.
    /// </summary>
    /// <param name="a">The first value object.</param>
    /// <param name="b">The second value object.</param>
    /// <returns>True if the value objects are not equal; otherwise, false.</returns>
    public static bool operator !=(ValueObject? a, ValueObject? b)
        => !(a == b);

    /// <summary>
    /// Gets the hash code for the value object based on its equality components.
    /// Generate hash code using XOR on hash codes of equality components.
    /// </summary>
    /// <returns>The hash code for the value object.</returns>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => true ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
}