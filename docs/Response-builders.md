> [← Go back](./Index.md)
# Response builders
This package provides helper methods to make [usage with Mediatr](Using-with-Mediatr.md) simpler. These builders can be used with generics when you don't know the type of the response object.

## Creating failed instances
To create a failed instance of any `IRequestResponse` ([which has a parameterless constructor](./Response-classes.md#implementing-your-own-response-class)) you can use the `CreateUnsuccessfulInstanceOf<TResponse>` methods.

```csharp
public static TResponse Example<TResponse>(IRequestErrors[] errors) where TResponse : IRequestResponse
{
    var response = CreateUnsuccessfulInstanceOf<TResponse>.WithdStatus(customStatus, errors);
    var invalidResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithInvalidStatus(errors);
    var unauthorizedResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithUnauthorizedStatus(errors);
    var paymentRequiredResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithPaymentRequiredStatus(errors);
    var forbiddenResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithForbiddenStatus(errors);
    var notFoundResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithNotFoundStatus(errors);
    var methodNotAllowedResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithMethodNotAllowedStatus(errors);
    var requestTimeoutResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithRequestTimeoutStatus(errors);
    var goneResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithGoneStatus(errors);
    var payloadTooLargeResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithPayloadTooLargeStatus(errors);
    var imATeapotResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithImATeapotStatus(errors);
    var tooManyRequestsResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithTooManyRequestsStatus(errors);
    var internalErrorResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithInternalErrorStatus(errors);
    var notImplementedResponse = CreateUnsuccessfulInstanceOf<TResponse>.WithNotImplementedStatus(errors);
}
```