> [← Go back](./Index.md)
# Response builders
This package provides helper methods to make usage with Mediatr simpler. These builders can be used with generics when you don't know the type of the response object.

## Creating failed instances
To create a failed instance of any response ([which implements the `Failure` static method](./Response-classes.md#implementing-your-own-response-class)) you can use the `CreateFailedInstanceOf<TResponse>` method.

```csharp
public static TResponse Example<TResponse>(IRequestErrors[] errors) where TResponse : IRequestResponse
{
    var response = ResultBuilders.CreateFailedInstanceOf<TResponse>(ResponseStatus.Invalid, errors);
}
```