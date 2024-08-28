namespace DevSource.Stack.Core.Application.Handlers.EventHandlers;

public interface IEventHandler<in TEvent>
{
    void Handle(TEvent @event);
}

public interface IEventHandler<in TEvent, out TResult>
{
    TResult Handle(TEvent @event);
}