namespace DevSource.Stack.Core.Repositories;

public interface IRepositoryAsync<TEntity> : 
    IReadRepositoryAsync<TEntity>, 
    IWriteRepositoryAsync<TEntity> 
    where TEntity : class;