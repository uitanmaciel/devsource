namespace DevSource.Stack.Core;

public interface IProcessCommand
{
    void ProcessCommand(ICommand command);
    T ProcessCommand<T>(ICommand command);
    Task ProcessCommandAsync(ICommand command, CancellationToken cancellationToken);
    Task<T> ProcessCommandAsync<T>(ICommand command, CancellationToken cancellationToken);
}