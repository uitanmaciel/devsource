namespace DevSource.Stack.Core.Application.Handlers.QueryHandlers;

public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
{
    TResult Handle(TQuery query);
}