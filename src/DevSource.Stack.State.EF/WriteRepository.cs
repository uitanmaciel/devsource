using DevSource.Stack.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevSource.Stack.State.EF;

public abstract class WriteRepository<TEntity, TContext>(TContext context) :
    IWriteRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected TContext Context { get; } = context;
    
    /// <summary>
    /// Synchronous adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <remarks>
    /// Implementations of this method should ensure the entity is added to the underlying storage mechanism.
    /// This might involve setting up the entity in a database, a file system, or any other form of storage.
    /// </remarks>
    public void Insert(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
    }
    
    /// <summary>
    /// Synchronous updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <remarks>
    /// This method should modify an existing entity's properties within the storage mechanism. 
    /// It is important that implementations handle concurrency and consistency checks where applicable.
    /// </remarks>
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
    }
    
    /// <summary>
    /// Synchronous deletes an entity from the repository.
    /// </summary>
    /// <param name="id">The id of entity to delete.</param>
    /// <remarks>
    /// Implementations should remove the entity from the storage mechanism. The method returns a boolean 
    /// indicating whether the deletion was successful. It's important to handle any constraints or dependencies
    /// that might prevent deletion, such as foreign key constraints.
    /// </remarks>
    public void Delete(dynamic id)
    {
        Context.Set<TEntity>().Remove(Context.Set<TEntity>().Find(id));
        Context.SaveChanges();
    }
}