namespace UnexceptionalResponses;

public static class RequestResponseBuilder
{
    public static TResponse InvokeStaticMethodOf<TResponse>(string methodName, params object[] parameters) where TResponse : IRequestResponse
    {
        var responseType = typeof(TResponse);
        var failureMethod = responseType.GetMethod(methodName);

        if (failureMethod is null) throw new ArgumentException($"{methodName} does not exist on {responseType.Name}");
        ;
        TResponse? callingResponseInstance = default;

        var response = (TResponse?)failureMethod.Invoke(callingResponseInstance, parameters);

        if (response is null) throw new InvalidOperationException($"{responseType}.{methodName} does not return {responseType}");

        return response;
    }

    public static TResponse CreateFailedInstanceOf<TResponse>(IResponseStatus responseStatus, IRequestError[] errors) where TResponse : IRequestResponse
        => InvokeStaticMethodOf<TResponse>(nameof(RequestResponse<object>.Failure), responseStatus, errors);
}
