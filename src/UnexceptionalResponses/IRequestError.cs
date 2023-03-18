namespace UnexceptionalResponses;

public interface IRequestError
{
    string Message { get; }
    string? Location { get; }
}
