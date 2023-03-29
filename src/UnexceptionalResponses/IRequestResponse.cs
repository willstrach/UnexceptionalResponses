namespace UnexceptionalResponses;

public interface IRequestResponse
{
    bool IsSuccessful { get; set; }
    IResponseStatus Status { get; set; }
    IRequestError[] Errors { get; set; }
}
