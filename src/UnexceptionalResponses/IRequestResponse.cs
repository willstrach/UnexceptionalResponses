namespace UnexceptionalResponses;

public interface IRequestResponse
{
    bool IsSuccessful { get; }
    IResponseStatus Status { get; }
    IRequestError[] Errors { get; }
}
