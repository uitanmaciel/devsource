namespace DevSource.Stack.Core;

public interface IProcessEvent
{
    void ProcessEvent(object @event);
    TResult ProcessEvent<TResult>(object @event);
}