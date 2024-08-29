using DevSource.Stack.Core;

namespace DevSource.Stack.Web;

public interface IRequestToCommand<TRequest, TCommand> where TCommand : ICommand
{
    static abstract TCommand ToCommand(TRequest request);
    static abstract IList<TCommand> ToCommand(IList<TRequest> requests);
}