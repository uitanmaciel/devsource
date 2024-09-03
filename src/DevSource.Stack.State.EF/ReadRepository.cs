using DevSource.Stack.Core.State;
using Microsoft.EntityFrameworkCore;

namespace DevSource.Stack.State.EF;

public abstract class ReadRepository<TEntity, TContext>(TContext context) :
    IReadRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected TContext Context { get; } = context;
    
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
    public TEntity GetById(Guid id)
        => Context
        .Set<TEntity>()
        .AsNoTracking()
        .FirstOrDefault(q => q.GetType().GetProperty("Id")!.Equals(id))!;
    
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
    public TEntity GetById(int id)
        => Context
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefault(q => q.GetType().GetProperty("Id")!.Equals(id))!;
    
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
    public TEntity GetById(Ulid id)
        => Context
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefault(q => q.GetType().GetProperty("Id")!.Equals(id))!;
}