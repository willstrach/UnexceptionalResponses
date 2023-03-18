> [← Go back](./Index.md)
# Using with Mediatr
The initial demand for this package cam from my own use of Mediatr, and my dislike for the usage of Exceptions in control flow. The classes and helpers in this package remove the need for this, making your apps more performant and readable.

## Using as a request's response type
Use the [response classes](./Response-classes.md) as you would any other response type. You can then return a successful instance using the `Success` method.
```csharp
public class MyRequest : IRequest<RequestResponse<MyRequestVm>>
{
    public int Id { get; set; }
}

public class MyRequestHandler : IRequestHandler<MyRequest, RequestResponse<MyRequestVm>>
{
    // ...

    return RequestResponse<MyRequestVm>.Success(ResponseStatus.Created, instanceOfMyRequestVm);
}
```

## Using in pipeline behaviours
Pipeline behaviours which halt the request handling pipeline are typically implemented using exceptions. We can achieve a cleaner implementation (subjective) using the [builder methods](./Response-builders.md).
```csharp
public class MyPipelineBehaviour<TRequest, TResponse> : IPipelineBehaviour<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IRequestResponse
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        // ..

        if (myErrors.Any())
        {
            return CreateFailedInstanceOf<TResponse>(ResponseStatus.Invalid, myErrors)
        }

        return await next;
    }
}
```