namespace UnexceptionalResponses;

public class RequestError : IRequestError
{
    public string Message { get; set; } = string.Empty;
    public string? Location { get; set; }

    public RequestError(string message, string? location = null)
    {
        Message = message;
        Location = location;
    }
}
