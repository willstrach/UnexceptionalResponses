namespace UnexceptionalResponses.UnitTests;

public class RequestResponseBuilderTests
{
    [Fact]
    public void InvokeStaticMethodOf_RequestResponseFailure_ShouldCreateFailedRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = new RequestError[] { };

        // Act
        var response = RequestResponseBuilder.InvokeStaticMethodOf<RequestResponse<ArbitraryResponseContent>>(nameof(RequestResponse<object>.Failure), responseStatus, errors);

        // Assert
        Assert.IsType<RequestResponse<ArbitraryResponseContent>>(response);
        Assert.False(response.IsSuccessful);
        Assert.Equal(responseStatus, response.Status);
        Assert.Equal(errors, response.Errors);
        Assert.Null(response.Content);
    }

    [Fact]
    public void InvokeStaticMethodOf_RequestResponseSuccess_ShouldCreateSuccessfulRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var responseContent = new ComparableResponseContent(100, "some string");

        // Act
        var response = RequestResponseBuilder.InvokeStaticMethodOf<RequestResponse<ComparableResponseContent>>(nameof(RequestResponse<object>.Success), responseStatus, responseContent);

        // Assert
        Assert.IsType<RequestResponse<ComparableResponseContent>>(response);
        Assert.True(response.IsSuccessful);
        Assert.Equal(responseStatus, response.Status);
        Assert.Empty(response.Errors);
        Assert.Equal(responseContent, response.Content);
    }

    [Fact]
    public void InvokeStaticMethodOf_PagedRequestResponseFailure_ShouldCreateFailedPagedRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = new RequestError[] { };

        // Act
        var response = RequestResponseBuilder.InvokeStaticMethodOf<PagedRequestResponse<ArbitraryResponseContent>>(nameof(RequestResponse<object>.Failure), responseStatus, errors);

        // Assert
        Assert.IsType<PagedRequestResponse<ArbitraryResponseContent>>(response);
        Assert.False(response.IsSuccessful);
        Assert.Equal(responseStatus, response.Status);
        Assert.Equal(errors, response.Errors);
        Assert.Null(response.Content);
    }

    [Fact]
    public void InvokeStaticMethodOf_PagedRequestResponseSuccess_ShouldCreateSuccessfulPagedRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var responseContent = new ComparableResponseContent(100, "some string");
        var pageMeta = new PageMeta();

        // Act
        var response = RequestResponseBuilder.InvokeStaticMethodOf<PagedRequestResponse<ComparableResponseContent>>(nameof(RequestResponse<object>.Success), responseStatus, responseContent, pageMeta);

        // Assert
        Assert.IsType<PagedRequestResponse<ComparableResponseContent>>(response);
        Assert.True(response.IsSuccessful);
        Assert.Equal(responseStatus, response.Status);
        Assert.Empty(response.Errors);
        Assert.Equal(responseContent, response.Content);
    }

    [Fact]
    public void CreateFailedInstanceOf_RequestResponse_ShouldCreateFailedRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = new RequestError[] { };

        // Act
        var response = RequestResponseBuilder.CreateFailedInstanceOf<RequestResponse<ArbitraryResponseContent>>(responseStatus, errors);

        // Assert
        Assert.IsType<RequestResponse<ArbitraryResponseContent>>(response);
        Assert.False(response.IsSuccessful);
        Assert.Equal(responseStatus, response.Status);
        Assert.Equal(errors, response.Errors);
        Assert.Null(response.Content);
    }

    [Fact]
    public void CreateFailedInstanceOf_PagedRequestResponse_ShouldCreateFailedPagedRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = new RequestError[] { };

        // Act
        var response = RequestResponseBuilder.CreateFailedInstanceOf<PagedRequestResponse<ArbitraryResponseContent>>(responseStatus, errors);

        // Assert
        Assert.IsType<PagedRequestResponse<ArbitraryResponseContent>>(response);
        Assert.False(response.IsSuccessful);
        Assert.Equal(responseStatus, response.Status);
        Assert.Equal(errors, response.Errors);
        Assert.Null(response.Content);
    }

    class ArbitraryResponseContent { }

    public class ComparableResponseContent
    {
        public ComparableResponseContent(int anInteger, string aString)
        {
            AnInteger = anInteger;
            AString = aString;
        }

        public int AnInteger { get; set; }
        public string AString { get; set; }
    }
}
