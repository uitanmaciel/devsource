namespace DevSource.Stack.Core;

public interface IProcessState
{
    void ProcessState(object obj);
    TResult ProcessState<TResult>(object obj);
}