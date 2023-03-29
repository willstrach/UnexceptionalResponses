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
    public static ResponseStatus PaymentRequired => new() { Message = "PaymentRequired", StatusCode = 402 };
    public static ResponseStatus Forbidden => new() { Message = "Forbidden", StatusCode = 403 };
    public static ResponseStatus NotFound => new() { Message = "NotFound", StatusCode = 404 };
    public static ResponseStatus MethodNotAllowed => new() { Message = "MethodNotAllowed", StatusCode = 405 };
    public static ResponseStatus RequestTimeout => new() { Message = "RequestTimeout", StatusCode = 408 };
    public static ResponseStatus Gone => new() { Message = "Gone", StatusCode = 410 };
    public static ResponseStatus PayloadTooLarge => new() { Message = "PayloadTooLarge", StatusCode = 413 };
    public static ResponseStatus ImATeapot => new() { Message = "ImATeapot", StatusCode = 418 };
    public static ResponseStatus TooManyRequests => new() { Message = "TooManyRequests", StatusCode = 429 };
    public static ResponseStatus InternalError => new() { Message = "InternalError", StatusCode = 500 };
    public static ResponseStatus NotImplemented => new() { Message = "NotImplemented", StatusCode = 501 };
}
