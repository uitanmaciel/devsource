namespace DevSource.Stack.Core;

public interface IProcessCommand
{
    void ProcessCommand(ICommand command);
    TResult ProcessCommand<TResult>(ICommand command);
    Task ProcessCommandAsync(ICommand command, CancellationToken cancellationToken);
    Task<TResult> ProcessCommandAsync<TResult>(ICommand command, CancellationToken cancellationToken);
}