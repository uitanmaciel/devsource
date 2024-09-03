﻿using DevSource.Stack.Core.State;
using Microsoft.EntityFrameworkCore;

namespace DevSource.Stack.State.EF;

public abstract class RepositoryBaseAsync<TEntity, TContext>(TContext context) :
    IRepositoryAsync<TEntity>
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
    
    /// <summary>
    /// Asynchronously adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">A token to cancel the operation if necessary.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation, returning an integer indicating the result of the operation.
    /// </returns>
    /// <remarks>
    /// Implementations should ensure that the entity is added to the underlying storage mechanism asynchronously. The integer return 
    /// value typically represents a status code or the number of entities added.
    /// </remarks>
    public async Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
        return await Context.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// Asynchronously updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">A token to cancel the operation if necessary.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation, returning an integer indicating the result of the operation.
    /// </returns>
    /// <remarks>
    /// This method should modify an existing entity's properties within the storage mechanism asynchronously. The integer return 
    /// value typically indicates a status code or the number of entities updated. Concurrency and consistency checks are important 
    /// considerations for implementations.
    /// </remarks>
    public async Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Context.Set<TEntity>().Update(entity);
        return await Context.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// Asynchronously deletes an entity from the repository.
    /// </summary>
    /// <param name="id">The id of entity to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation if necessary.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation, returning a boolean indicating whether the deletion was successful.
    /// </returns>
    /// <remarks>
    /// Implementations should remove the entity from the storage mechanism asynchronously. The boolean return value indicates the 
    /// success or failure of the deletion. Handling dependencies and constraints that might prevent deletion (like foreign key constraints) 
    /// is an important aspect of the implementation.
    /// </remarks>
    public async Task<bool> DeleteAsync(dynamic id, CancellationToken cancellationToken)
    {
        var entity = await Context.Set<TEntity>().FindAsync(id, cancellationToken);
        if (entity is null)
            return false;

        Context.Set<TEntity>().Remove(entity);
        return await Context.SaveChangesAsync(cancellationToken) > 0;
    }
}