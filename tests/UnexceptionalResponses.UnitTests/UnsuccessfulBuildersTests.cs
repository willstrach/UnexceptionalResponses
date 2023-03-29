using System.Reflection;

namespace UnexceptionalResponses.UnitTests;

public class UnsuccessfulBuildersTests
{
    class ArbitraryContent { }

    [Fact]
    public void WithStatus_UsingArbitraryStatus_ShouldHaveFalseIsSuccessful()
    {
        // Arrange
        var status = new ResponseStatus()
        {
            Message = "Arbitrary",
            StatusCode = 999,
        };
        var errors = Array.Empty<RequestError>();

        // Act
        var response = CreateUnsuccessfulInstanceOf<RequestResponse<ArbitraryContent>>.WithStatus(status, errors);

        // Assert
        Assert.False(response.IsSuccessful);
    }

    [Fact]
    public void WithStatus_UsingArbitraryStatus_ShouldHaveCorrectStatus()
    {
        // Arrange
        var status = new ResponseStatus()
        {
            Message = "Arbitrary",
            StatusCode = 999,
        };
        var errors = Array.Empty<RequestError>();

        // Act
        var response = CreateUnsuccessfulInstanceOf<RequestResponse<ArbitraryContent>>.WithStatus(status, errors);

        // Assert
        Assert.Equal(status.Message, response.Status.Message);
        Assert.Equal(status.StatusCode, response.Status.StatusCode);
    }

    [Fact]
    public void WithStatus_UsingArbitraryStatus_ShouldHaveCorrectErrors()
    {
        // Arrange
        var status = new ResponseStatus()
        {
            Message = "Arbitrary",
            StatusCode = 999,
        };
        var errors = new RequestError[]
        {
            new("one"),
            new("two"),
            new("three"),
        };

        // Act
        var response = CreateUnsuccessfulInstanceOf<RequestResponse<ArbitraryContent>>.WithStatus(status, errors);

        // Assert
        Assert.NotEmpty(response.Errors);
        Assert.Equal(errors, response.Errors);
    }

    public static IEnumerable<object[]> GetStatusBuilders()
    {
        var builder = typeof(CreateUnsuccessfulInstanceOf<RequestResponse<object>>);
        yield return new object[] { builder.GetMethod("WithInvalidStatus")!, ResponseStatus.Invalid };
        yield return new object[] { builder.GetMethod("WithUnauthorizedStatus")!, ResponseStatus.Unauthorized };
        yield return new object[] { builder.GetMethod("WithPaymentRequiredStatus")!, ResponseStatus.PaymentRequired };
        yield return new object[] { builder.GetMethod("WithForbiddenStatus")!, ResponseStatus.Forbidden };
        yield return new object[] { builder.GetMethod("WithNotFoundStatus")!, ResponseStatus.NotFound };
        yield return new object[] { builder.GetMethod("WithMethodNotAllowedStatus")!, ResponseStatus.MethodNotAllowed };
        yield return new object[] { builder.GetMethod("WithRequestTimeoutStatus")!, ResponseStatus.RequestTimeout };
        yield return new object[] { builder.GetMethod("WithGoneStatus")!, ResponseStatus.Gone };
        yield return new object[] { builder.GetMethod("WithPayloadTooLargeStatus")!, ResponseStatus.PayloadTooLarge };
        yield return new object[] { builder.GetMethod("WithImATeapotStatus")!, ResponseStatus.ImATeapot };
        yield return new object[] { builder.GetMethod("WithTooManyRequestsStatus")!, ResponseStatus.TooManyRequests };
        yield return new object[] { builder.GetMethod("WithInternalErrorStatus")!, ResponseStatus.InternalError };
        yield return new object[] { builder.GetMethod("WithNotImplementedStatus")!, ResponseStatus.NotImplemented };
    }

    [Theory]
    [MemberData(nameof(GetStatusBuilders))]
    public void WithPassedStatus_UsingArbitraryErrors_ShouldHaveFalseIsSuccessful(MethodInfo method, IResponseStatus expectedStatus)
    {
        // Arrange
        var errors = Array.Empty<IRequestError>();

        // Act
        var response = method.Invoke(null, new object[] { errors }) as IRequestResponse;

        // Assert
        Assert.NotNull(response);
        Assert.False(response!.IsSuccessful);
    }

    [Theory]
    [MemberData(nameof(GetStatusBuilders))]
    public void WithPassedStatus_UsingArbitraryErrors_ShouldHaveCorrectStatus(MethodInfo method, IResponseStatus expectedStatus)
    {
        // Arrange
        var errors = Array.Empty<IRequestError>();

        // Act
        var response = method.Invoke(null, new object[] { errors }) as IRequestResponse;

        // Assert
        Assert.Equal(expectedStatus.Message, response!.Status.Message);
        Assert.Equal(expectedStatus.StatusCode, response.Status.StatusCode);
    }
}
