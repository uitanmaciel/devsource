namespace DevSource.Stack.Core.Repositories;

public interface IRepository<TEntity> :
    IReadRepository<TEntity>, 
    IWriteRepository<TEntity> 
    where TEntity : class;