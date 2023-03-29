namespace UnexceptionalResponses;

public static class CreateUnsuccessfulInstanceOf<TResponse> where TResponse : IRequestResponse, new()
{
    public static TResponse WithStatus(IResponseStatus status, params IRequestError[] errors)
    {
        var response = new TResponse()
        {
            IsSuccessful = false,
            Errors = errors,
            Status = status,
        };
        return response;
    }

    public static TResponse WithInvalidStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.Invalid, errors);

    public static TResponse WithUnauthorizedStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.Unauthorized, errors);

    public static TResponse WithPaymentRequiredStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.PaymentRequired, errors);

    public static TResponse WithForbiddenStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.Forbidden, errors);

    public static TResponse WithNotFoundStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.NotFound, errors);

    public static TResponse WithMethodNotAllowedStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.MethodNotAllowed, errors);

    public static TResponse WithRequestTimeoutStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.RequestTimeout, errors);

    public static TResponse WithGoneStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.Gone, errors);

    public static TResponse WithPayloadTooLargeStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.PayloadTooLarge, errors);

    public static TResponse WithImATeapotStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.ImATeapot, errors);

    public static TResponse WithTooManyRequestsStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.TooManyRequests, errors);

    public static TResponse WithInternalErrorStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.InternalError, errors);

    public static TResponse WithNotImplementedStatus(params IRequestError[] errors)
        => WithStatus(ResponseStatus.NotImplemented, errors);
}
