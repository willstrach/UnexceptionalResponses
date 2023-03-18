namespace UnexceptionalResponses;

public interface IResponseStatus
{
    int StatusCode { get; }
    string Message { get; }
}
