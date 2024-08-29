namespace DevSource.Stack.Core.State;

public interface IRepositoryAsync<TEntity> : 
    IReadRepositoryAsync<TEntity>, 
    IWriteRepositoryAsync<TEntity> 
    where TEntity : class;