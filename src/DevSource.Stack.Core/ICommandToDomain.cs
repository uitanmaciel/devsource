namespace DevSource.Stack.Core;

public interface ICommandToDomain<TCommand, TDomain> where TCommand : ICommand
{
    TDomain ToDomain(TCommand command);
    IList<TDomain> ToDomain(IList<TCommand> command);
}