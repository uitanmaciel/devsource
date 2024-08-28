namespace DevSource.Stack.Core.Application.Handlers.CommandHandlers;

public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandlerAsync<in TCommand, TResult> where TCommand : ICommand
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
}