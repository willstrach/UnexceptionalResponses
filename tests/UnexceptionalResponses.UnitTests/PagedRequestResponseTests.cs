namespace UnexceptionalResponses.UnitTests;

public class PagedPagedRequestResponseTests
{
    [Fact]
    public void Success_WithArbitraryContent_ShouldHaveTrueIsSuccessful()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Success(ResponseStatus.Ok, responseContent, pageMeta);

        // Assert
        Assert.True(response.IsSuccessful);
    }

    [Fact]
    public void Success_WithOkStatus_ShouldHaveCorrectStatus()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();
        var responseStatus = ResponseStatus.Ok;
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Success(responseStatus, responseContent, pageMeta);

        // Assert
        Assert.Equal(responseStatus, response.Status);
    }

    [Fact]
    public void Success_WithCreatedStatus_ShouldHaveCorrectStatus()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();
        var responseStatus = ResponseStatus.Created;
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Success(responseStatus, responseContent, pageMeta);

        // Assert
        Assert.Equal(responseStatus, response.Status);
    }

    [Fact]
    public void Success_WithArbitraryContent_ShouldHaveNoErrors()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Success(ResponseStatus.Ok, responseContent, pageMeta);

        // Assert
        Assert.Empty(response.Errors);
    }

    [Fact]
    public void Success_WithComparableResponseContent_ShouldHaveCorrectContent()
    {
        // Arrange
        var responseContent = new ComparableResponseContent(10, "something");
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ComparableResponseContent>.Success(ResponseStatus.Ok, responseContent, pageMeta);

        // Assert
        Assert.IsType<ComparableResponseContent>(response.Content);
        Assert.Equal(responseContent, response.Content);
    }

    [Fact]
    public void Failure_WithArbitraryContent_ShouldHaveFalseISuccessful()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = new RequestError[]
        {
            new("Arbitrary message"),
            new("Another arbitrary message"),
        };

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        Assert.False(response.IsSuccessful);
    }

    [Fact]
    public void Failure_WithArbitraryContent_ShouldHaveNullContent()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = new RequestError[]
        {
            new("Arbitrary message"),
            new("Another arbitrary message"),
        };

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        Assert.Null(response.Content);
    }

    [Fact]
    public void Failure_WithInvalidStatus_ShouldHaveCorrectStatus()
    {
        // Arrange
        var responseStatus = ResponseStatus.Invalid;
        var errors = new RequestError[]
        {
            new("Arbitrary message"),
            new("Another arbitrary message"),
        };

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        Assert.Equal(responseStatus, response.Status);
    }

    [Fact]
    public void Failure_WithUnauthorizedStatus_ShouldHaveCorrectStatus()
    {
        // Arrange
        var responseStatus = ResponseStatus.Unauthorized;
        var errors = new RequestError[]
        {
            new("Arbitrary message"),
            new("Another arbitrary message"),
        };

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        Assert.Equal(responseStatus, response.Status);
    }

    [Fact]
    public void Failure_WithNoErrors_ShouldHaveEmptyErrors()
    {
        // Arrange
        var responseStatus = ResponseStatus.Unauthorized;
        var errors = new RequestError[] { };

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        Assert.Empty(response.Errors);
    }

    [Fact]
    public void Failure_WithErrors_ShouldHaveEmptyErrors()
    {
        // Arrange
        var responseStatus = ResponseStatus.Unauthorized;
        var errors = new RequestError[]
        {
            new("Arbitrary message", "ArbitraryLocation"),
            new("Another arbitrary message", "AnotherLocation"),
        };

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        Assert.NotEmpty(response.Errors);
        Assert.Equal(errors, response.Errors);
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
