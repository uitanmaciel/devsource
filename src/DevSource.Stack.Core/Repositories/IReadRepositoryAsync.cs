namespace DevSource.Stack.Core.Repositories;

public interface IReadRepositoryAsync<TEntity> where TEntity : class
{
    /// <summary>
    /// Asynchronously retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation if necessary.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, which, upon completion, 
    /// returns the entity with the specified identifier or null if not found.
    /// </returns>
    /// <remarks>
    /// Implementations should ensure asynchronous access to the underlying storage to retrieve the specified entity. 
    /// The method is expected to return null if the entity is not found, thereby not throwing an exception for a 
    /// non-existent entity.
    /// </remarks>
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Asynchronously retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation if necessary.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, which, upon completion, 
    /// returns the entity with the specified identifier or null if not found.
    /// </returns>
    /// <remarks>
    /// Implementations should ensure asynchronous access to the underlying storage to retrieve the specified entity. 
    /// The method is expected to return null if the entity is not found, thereby not throwing an exception for a 
    /// non-existent entity.
    /// </remarks>
    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Asynchronously retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation if necessary.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, which, upon completion, 
    /// returns the entity with the specified identifier or null if not found.
    /// </returns>
    /// <remarks>
    /// Implementations should ensure asynchronous access to the underlying storage to retrieve the specified entity. 
    /// The method is expected to return null if the entity is not found, thereby not throwing an exception for a 
    /// non-existent entity.
    /// </remarks>
    Task<TEntity> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
}