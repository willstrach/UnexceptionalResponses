> [← Go back](./Index.md)
# Using with Mediatr

## Using as a request's response type
```csharp
public class MyRequest : IRequest<RequestResponse<MyRequestVm>>
{
    public int Id { get; set; }
}

public class MyRequestHandler : IRequestHandler<MyRequest, RequestResponse<MyRequestVm>>
{
    // ...
}
```

## Using in pipeline behaviours