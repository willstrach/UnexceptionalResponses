# UnexceptionalResponses
Easy to use response classes allowing you to communicate errors without throwing exceptions. Primarily designed for use with Mediatr, allowing pipeline behaviours to return early without using exceptions or weird response classes.

## Installing UnexceptionalResponses
You can install using NuGet:
```dotnetcli
Install-Package UnexceptionalResponses
```

or using the .NET CLI:
```dotnetcli
dotnet add package UexceptionalResponses
```

or using Visual Studio's NuGet package manager.

## Getting started
The easiest way to get started is to [read the docs](./docs/Index.md).

## The RequestResponse class
The package's most simple response class, allowing arbitrary content to be passed with additional metadata around the request's success, status, and any errors. For more on the built-in responses classes, and how to create your own, [read the docs](./docs//Response-classes.md).

```csharp
public class RequestResponse<TContent> : IRequestResponse
{
    public bool IsSuccessful { get; private set; }
    public IResponseStatus Status { get; private set; }
    public IRequestError[] Errors { get; private set; }
    public TContent? Content { get; set; }

    // ...
}
```

## Easy to use with Mediatr pipeline behaviours
The response classes are designed to work cleanly with Mediatr with different response classes and content. The particular response object is identified using reflection, providing better performance than the typical exception-based method. For more on how to use this library with Mediatr, [read the docs](./docs/Using-with-Mediatr.md).

```csharp
public class MyPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : IRequest<TResponse> where TResponse : IRequestResponse
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        // Do something...
 
        if (somethingWentWrong)
        {
            return ResultBuilder.CreateFailedInstanceOf<TResponse>(ResponseStatus.InternalError, requestErrors);
        }

        return await next();
    }
}
```

