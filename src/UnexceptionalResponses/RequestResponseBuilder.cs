namespace UnexceptionalResponses;

[Obsolete("RequestResponseBuilderIsDepreciated, please use CreateUnsuccessfulInstanceOf<> instead")]
public static class RequestResponseBuilder
{
    public static TResponse InvokeStaticMethodOf<TResponse>(string methodName, params object[] parameters) where TResponse : IRequestResponse
    {
        var responseType = typeof(TResponse);
        var failureMethod = responseType.GetMethod(methodName) ?? throw new ArgumentException($"{methodName} does not exist on {responseType.Name}");
        TResponse? callingResponseInstance = default;

        var response = (TResponse?)failureMethod.Invoke(callingResponseInstance, parameters);

        return response ?? throw new InvalidOperationException($"{responseType}.{methodName} does not return {responseType}");
    }

    public static TResponse CreateFailedInstanceOf<TResponse>(IResponseStatus responseStatus, IRequestError[] errors) where TResponse : IRequestResponse
        => InvokeStaticMethodOf<TResponse>(nameof(RequestResponse<object>.Failure), responseStatus, errors);
}
