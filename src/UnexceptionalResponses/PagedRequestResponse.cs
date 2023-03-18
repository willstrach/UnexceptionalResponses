namespace UnexceptionalResponses;

public class PagedRequestResponse<TContent> : RequestResponse<TContent> where TContent : class
{
    public PagedRequestResponse(bool isSuccessful, IResponseStatus status, IRequestError[]? errors = null, TContent? content = default, PageMeta? pageMeta = null)
        : base(isSuccessful, status, errors, content)
    {
        PageMeta = pageMeta ?? new();
    }

    public PageMeta PageMeta { get; set; }

    public static PagedRequestResponse<TContent> Success(IResponseStatus responseStatus, TContent content, PageMeta pageMeta)
    {
        var response = new PagedRequestResponse<TContent>(true, responseStatus, null, content, pageMeta);
        return response;
    }

    public static new PagedRequestResponse<TContent> Failure(IResponseStatus responseStatus, RequestError[] errors)
    {
        var response = new PagedRequestResponse<TContent>(false, responseStatus, errors, null);
        return response;
    }
}

public class PageMeta
{
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}
