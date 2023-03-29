namespace UnexceptionalResponses;

public class RequestResponse<TContent> : IRequestResponse
{
    public bool IsSuccessful { get; set; }
    public IResponseStatus Status { get; set; } = ResponseStatus.InternalError;
    public IRequestError[] Errors { get; set; } = Array.Empty<IRequestError>();
    public TContent? Content { get; set; }

    public RequestResponse() { }

    public RequestResponse(bool isSuccessful, IResponseStatus status, IRequestError[]? errors = null, TContent? content = default)
    {
        IsSuccessful = isSuccessful;
        Status = status;
        Errors = errors ?? Array.Empty<IRequestError>();
        Content = content;
    }

    public static RequestResponse<TContent> Success(IResponseStatus responseStatus, TContent content) => new(true, responseStatus, content: content);
    public static RequestResponse<TContent> Failure(IResponseStatus responseStatus, RequestError[] errors) => new(false, responseStatus, errors: errors);
}

public static class RequestResponse
{
    public static RequestResponse<TContent> Ok<TContent>(TContent content)
        => RequestResponse<TContent>.Success(ResponseStatus.Ok, content);

    public static RequestResponse<TContent> Created<TContent>(TContent content)
        => RequestResponse<TContent>.Success(ResponseStatus.Created, content);

    public static RequestResponse<TContent> Accepted<TContent>(TContent content)
        => RequestResponse<TContent>.Success(ResponseStatus.Accepted, content);
}