namespace UnexceptionalResponses;

public class RequestResponse<TContent> : IRequestResponse
{
    public bool IsSuccessful { get; private set; }
    public IResponseStatus Status { get; private set; }
    public IRequestError[] Errors { get; private set; }
    public TContent? Content { get; set; }

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
