> [← Go back](./Index.md)
# Request errors
The `RequestError` class is a simple class for representing an error and its location.
```csharp
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

```
- **Message:** A description of the error
- **Location:** An optional string to give the property or argument that the error corresponds to

## Implementing your own errors
To use the built-in classes and methods, all request errors must implement `IRequestError`.
