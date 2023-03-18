namespace UnexceptionalResponses;

public class ResponseStatus : IResponseStatus
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;

    public static ResponseStatus Ok => new() { Message = "OK", StatusCode = 200 };
    public static ResponseStatus Created => new() { Message = "Created", StatusCode = 201 };
    public static ResponseStatus Accepted => new() { Message = "Accepted", StatusCode = 201 };
    public static ResponseStatus Invalid => new() { Message = "Invalid", StatusCode = 400 };
    public static ResponseStatus Unauthorized => new() { Message = "Unauthorized", StatusCode = 401 };
    public static ResponseStatus Forbidden => new() { Message = "Forbidden", StatusCode = 403 };
    public static ResponseStatus InternalError => new() { Message = "InternalError", StatusCode = 500 };
}
