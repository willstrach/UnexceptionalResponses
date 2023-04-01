namespace UnexceptionalResponses.UnitTests;

[Obsolete("Tests kept for backwards compatibility")]
public class RequestResponseBuilderTests
{
    [Fact]
    public void InvokeStaticMethodOf_RequestResponseFailure_ShouldCreateFailedRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = Array.Empty<RequestError>();

        // Act
        var response = RequestResponseBuilder.InvokeStaticMethodOf<RequestResponse<ArbitraryResponseContent>>(nameof(RequestResponse<object>.Failure), responseStatus, errors);

        // Assert
        Assert.IsType<RequestResponse<ArbitraryResponseContent>>(response);
        Assert.False(response.IsSuccessful);
        response.Status.Should().BeEquivalentTo(responseStatus);
        response.Errors.Should().BeEquivalentTo(errors);
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
        response.Should().BeOfType<RequestResponse<ComparableResponseContent>>();
        response.IsSuccessful.Should().BeTrue();
        response.Status.Should().BeEquivalentTo(responseStatus);
        response.Errors.Should().BeEmpty();
        response.Content.Should().BeEquivalentTo(responseContent);
    }

    [Fact]
    public void InvokeStaticMethodOf_PagedRequestResponseFailure_ShouldCreateFailedPagedRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = Array.Empty<RequestError>();

        // Act
        var response = RequestResponseBuilder.InvokeStaticMethodOf<PagedRequestResponse<ArbitraryResponseContent>>(nameof(RequestResponse<object>.Failure), responseStatus, errors);

        // Assert
        response.Should().BeOfType<PagedRequestResponse<ArbitraryResponseContent>>();
        response.IsSuccessful.Should().BeFalse();
        response.Status.Should().BeEquivalentTo(responseStatus);
        response.Errors.Should().BeEquivalentTo(errors);
        response.Content.Should().BeNull();
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
        response.Should().BeOfType<PagedRequestResponse<ComparableResponseContent>>();
        response.IsSuccessful.Should().BeTrue();
        response.Status.Should().BeEquivalentTo(responseStatus);
        response.Errors.Should().BeEmpty();
        response.Content.Should().BeEquivalentTo(responseContent);
    }

    [Fact]
    public void CreateFailedInstanceOf_RequestResponse_ShouldCreateFailedRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = Array.Empty<RequestError>();

        // Act
        var response = RequestResponseBuilder.CreateFailedInstanceOf<RequestResponse<ArbitraryResponseContent>>(responseStatus, errors);

        // Assert
        response.Should().BeOfType<RequestResponse<ArbitraryResponseContent>>();
        response.IsSuccessful.Should().BeFalse();
        response.Status.Should().BeEquivalentTo(responseStatus);
        response.Errors.Should().BeEquivalentTo(errors);
        response.Content.Should().BeNull();
    }

    [Fact]
    public void CreateFailedInstanceOf_PagedRequestResponse_ShouldCreateFailedPagedRequestResponse()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = Array.Empty<RequestError>();

        // Act
        var response = RequestResponseBuilder.CreateFailedInstanceOf<PagedRequestResponse<ArbitraryResponseContent>>(responseStatus, errors);

        // Assert
        response.Should().BeOfType<PagedRequestResponse<ArbitraryResponseContent>>();
        response.IsSuccessful.Should().BeFalse();
        response.Status.Should().BeEquivalentTo(responseStatus);
        response.Errors.Should().BeEquivalentTo(errors);
        response.Content.Should().BeNull();
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
