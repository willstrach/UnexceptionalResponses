namespace UnexceptionalResponses;

public class PagedRequestResponse<TContent> : RequestResponse<TContent>
{
    public PageMeta PageMeta { get; set; } = new();
    public PagedRequestResponse() { }

    public PagedRequestResponse(bool isSuccessful, IResponseStatus status, IRequestError[]? errors = null, TContent? content = default, PageMeta? pageMeta = null)
        : base(isSuccessful, status, errors, content)
    {
        PageMeta = pageMeta ?? new();
    }

    [Obsolete("Use PagedRequestResponse.WithSuccessfulStatus instead")]
    public static PagedRequestResponse<TContent> Success(IResponseStatus responseStatus, TContent content, PageMeta pageMeta)
    {
        var response = new PagedRequestResponse<TContent>(true, responseStatus, null, content, pageMeta);
        return response;
    }

    [Obsolete("Use PagedRequestResponse.WithFailedStatus instead")]
    public static new PagedRequestResponse<TContent> Failure(IResponseStatus responseStatus, RequestError[] errors)
    {
        var response = new PagedRequestResponse<TContent>(false, responseStatus, errors, default);
        return response;
    }
}

public static class PagedRequestResponse
{
    public static PagedRequestResponse<TContent> WithSuccessfulStatus<TContent>(IResponseStatus responseStatus, TContent content, PageMeta pageMeta)
        => new(true, responseStatus, content: content, pageMeta: pageMeta);

    public static PagedRequestResponse<TContent> WithFailedStatus<TContent>(IResponseStatus responseStatus, RequestError[] errors)
        => new(false, responseStatus, errors: errors);

    public static PagedRequestResponse<TContent> Ok<TContent>(TContent content, PageMeta pageMeta)
        => WithSuccessfulStatus(ResponseStatus.Ok, content, pageMeta);
}

public class PageMeta
{
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}
