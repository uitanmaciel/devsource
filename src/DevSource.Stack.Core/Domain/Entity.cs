using DevSource.Stack.Notifications;

namespace DevSource.Stack.Core.Domain;

public abstract class Entity() : Notifier, IEquatable<Entity>
{
    /// <summary>
    /// Gets the unique identifier of the entity.
    /// </summary>
    public dynamic Id { get; set; } = null!;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the entity.</param>
    protected Entity(dynamic id) : this() => Id = id;
    
    /// <summary>
    /// Determines whether the current entity is equal to another entity.
    /// </summary>
    /// <param name="other">The entity to compare with the current entity.</param>
    /// <returns>True if the entities are equal; otherwise, false.</returns>
    public bool Equals(Entity? other)
    {
        if (ReferenceEquals(null, other)) return false;
        return ReferenceEquals(this, other) || Id.Equals(other.Id);
    }

    /// <summary>
    /// Determines whether the current entity is equal to an object.
    /// </summary>
    /// <param name="obj">The object to compare with the current entity.</param>
    /// <returns>True if the object is an entity and is equal to the current entity; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Entity)obj);
    }
    
    /// <summary>
    /// Generates a hash code for the current entity.
    /// </summary>
    /// <returns>A hash code based on the entity's type and unique identifier.</returns>
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Id);
    
    /// <summary>
    /// Determines whether two entities are equal.
    /// </summary>
    /// <param name="left">The first entity to compare.</param>
    /// <param name="right">The second entity to compare.</param>
    /// <returns>True if the entities are equal; otherwise, false.</returns>
    public static bool operator ==(Entity? left, Entity? right) => left?.Equals(right) ?? false;

    /// <summary>
    /// Determines whether two entities are not equal.
    /// </summary>
    /// <param name="left">The first entity to compare.</param>
    /// <param name="right">The second entity to compare.</param>
    /// <returns>True if the entities are not equal; otherwise, false.</returns>
    public static bool operator !=(Entity? left, Entity? right) => !(left == right);
}