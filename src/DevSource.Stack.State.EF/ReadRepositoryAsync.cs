using DevSource.Stack.Core.State;
using Microsoft.EntityFrameworkCore;

namespace DevSource.Stack.State.EF;

public abstract class ReadRepositoryAsync<TEntity, TContext>(TContext context) :
    IReadRepositoryAsync<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected TContext Context { get; } = context;

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
    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => (await Context
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.GetType().GetProperty("Id")!.Equals(id), cancellationToken))!;
    
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
    public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        => (await Context
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.GetType().GetProperty("Id")!.Equals(id), cancellationToken))!;
    
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
    public async Task<TEntity> GetByIdAsync(Ulid id, CancellationToken cancellationToken)
        => (await Context
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.GetType().GetProperty("Id")!.Equals(id), cancellationToken))!;
}