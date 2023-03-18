> [← Go back](./Index.md)
# Response classes
This package provides two response classes out of the box: [`RequestResponse<TContent>`](#requestresponsetcontent) and [`PagedRequestResponse<TContent>`](#pagedrequestresponsetcontent), with the ability to [implement your own](#implementing-your-own-response-class).

## RequestResponse\<TContent>
The request response class allows arbitrary content to be passed alongside additional information on the request's success, status and any errors that may have occured.

```csharp
public class RequestResponse<TContent> : IRequestResponse
{
    public bool IsSuccessful { get; }
    public IResponseStatus Status { get; }
    public IRequestError[] Errors { get; }
    public TContent? Content { get; }

   // ...
}
```

- **IsSuccessful:** True if the request was successful
- **Status:** The status of the request (for more on the response status, [click here](./Response-statuses.md))
- **Errors:** Any errors that occurred during the execution of the request (for more on request errors, [click here](./Request-errors.md))
- **Content:** The content returned by the request

### Intantiating the class
While the class does have a public constructor, it is recommended that you use one of the static provided static methods.

For creating successful instances of the class, use the `Success` method:
```csharp
var response = RequestResponse<ResponseContent>.Success(ResponseStatus.Ok, anInstanceOfResponseContent);
```
> **Note:** This helper does not allow errors when creating a successful result. The errors will be set to `Array.Empty<IRequestError>()`

Failed instances of the class can also be created using the `Falure` method:
```csharp
var someErrors = new RequestError[]
{
    new("An error message", "TheLocation"),
}

var response = RequestResponse<ResponseContent>.Failure(ResponseStatus.Invalid, someErrors);
```
> **Note:** This helper does not allow content when creating a failed result. The content will be set to `null`

## PagedRequestResponse\<TContent>
The paged request response class builds upon the request response class, providing extra information for paged requests.

```csharp
public class PagedRequestResponse<TContent> : IRequestResponse
{
    public bool IsSuccessful { get; }
    public IResponseStatus Status { get; }
    public IRequestError[] Errors { get; }
    public TContent? Content { get; }
    public PageMeta PageMeta { get; }

   // ...
}

public class PageMeta
{
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}
```
- **PageMeta:** Information about the current page and amount of pages

### Intantiating the class
While the class does have a public constructor, it is recommended that you use one of the static provided static methods.

For creating successful instances of the class, use the `Success` method:
```csharp
var response = PagedRequestResponse<ResponseContent>.Success(ResponseStatus.Ok, anInstanceOfResponseContent, pageMeta);
```
> **Note:** This helper does not allow errors when creating a successful result. The errors will be set to `Array.Empty<IRequestError>()`

Failed instances of the class can also be created using the `Falure` method:
```csharp
var someErrors = new RequestError[]
{
    new("An error message", "TheLocation"),
}

var response = PagedRequestResponse<ResponseContent>.Failure(ResponseStatus.Invalid, someErrors);
```
> **Note:** This helper does not allow content or pageMeta when creating a failed result. The content will be set to `null` and the page meta values to `0`

## Implementing your own response class
This package can be used as a basis for creating your own response classes. To use the [`ResponseBuilder` methods](./Response-builders.md), all response classes must implement `IRequestResponse` and implement the static method `Failure` with the following parameters:
```csharp
public static RequestResponse<TContent> Failure(IResponseStatus responseStatus, RequestError[] errors)
{
    // ...
}
```
