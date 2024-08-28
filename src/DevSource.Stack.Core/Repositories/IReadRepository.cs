namespace DevSource.Stack.Core.Repositories;

public interface IReadRepository<out TEntity> where TEntity : class
{
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>
    /// The entity with the specified identifier, or null if the entity is not found.
    /// </returns>
    /// <remarks>
    /// This method provides a straightforward way to access a single entity based on its identifier. 
    /// It should return null if the entity is not found, instead of throwing an exception.
    /// </remarks>
    TEntity GetById(Guid id);
    
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>
    /// The entity with the specified identifier, or null if the entity is not found.
    /// </returns>
    /// <remarks>
    /// This method provides a straightforward way to access a single entity based on its identifier. 
    /// It should return null if the entity is not found, instead of throwing an exception.
    /// </remarks>
    TEntity GetById(int id);
    
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>
    /// The entity with the specified identifier, or null if the entity is not found.
    /// </returns>
    /// <remarks>
    /// This method provides a straightforward way to access a single entity based on its identifier. 
    /// It should return null if the entity is not found, instead of throwing an exception.
    /// </remarks>
    TEntity GetById(Ulid id);
}