namespace DevSource.Stack.Core.Communication;

public abstract class Dispatcher
{
    protected static object InvokeHandlerMethod(
        dynamic obj,
        IServiceProvider provider,
        Type handlerBaseType,
        string methodName,
        Type[]? additionalTypes = null,
        object[]? additionalParams = null)
    {
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));
        ArgumentNullException.ThrowIfNull(provider, nameof(provider));
        ArgumentNullException.ThrowIfNull(handlerBaseType, nameof(handlerBaseType));
        ArgumentException.ThrowIfNullOrEmpty(methodName, nameof(methodName));

        Type[] genericTypes;
        if(additionalTypes == null)
            genericTypes = new Type[] {obj.GetType()};
        else
        {
            genericTypes = new Type[additionalTypes.Length + 1];
            genericTypes[0] = obj.GetType();
            Array.Copy(additionalTypes, 0, genericTypes, 1, additionalTypes.Length);
        }
        
        var handlerType = handlerBaseType.MakeGenericType(genericTypes);
        var handler = provider.GetService(handlerType);
        if(handler == null)
            throw new InvalidOperationException($"Handler of type {handlerType} not found.");
        
        var method = handlerType.GetMethod(methodName);
        if(method == null)
            throw new InvalidOperationException($"Method {methodName} not found in handler of type {handlerType}.");
        
        var parameters = new List<object> {obj};
        if(additionalParams != null)
            parameters.AddRange(additionalParams);
        
        return method.Invoke(handler, parameters.ToArray())!;
    }
}