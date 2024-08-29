namespace DevSource.Stack.Core.State;

public interface IRepository<TEntity> :
    IReadRepository<TEntity>, 
    IWriteRepository<TEntity> 
    where TEntity : class;