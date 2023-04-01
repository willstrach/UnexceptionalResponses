namespace UnexceptionalResponses.UnitTests;

public class PagedPagedRequestResponseTests
{
    [Fact]
    public void Ok_WithArbitraryContent_ShouldHaveTrueIsSuccessful()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = PagedRequestResponse.Ok(responseContent, new());

        // Assert
        response.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Ok_WithArbitraryContent_ShouldHaveCorrectStatus()
    {
        // Arrange
        var expectedStatus = ResponseStatus.Ok;
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = PagedRequestResponse.Ok(responseContent, new());

        // Assert
        response.Status.Should().BeEquivalentTo(expectedStatus);
    }

    [Fact]
    public void Ok_WithArbitraryContent_ShouldHaveCorrectContent()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = PagedRequestResponse.Ok(responseContent, new());

        // Assert
        response.Content.Should().BeEquivalentTo(responseContent);
    }


    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Success_WithArbitraryContent_ShouldHaveTrueIsSuccessful()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Success(ResponseStatus.Ok, responseContent, pageMeta);

        // Assert
        response.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Success_WithOkStatus_ShouldHaveCorrectStatus()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();
        var responseStatus = ResponseStatus.Ok;
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Success(responseStatus, responseContent, pageMeta);

        // Assert
        response.Status.Should().BeEquivalentTo(responseStatus);
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Success_WithCreatedStatus_ShouldHaveCorrectStatus()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();
        var responseStatus = ResponseStatus.Created;
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Success(responseStatus, responseContent, pageMeta);

        // Assert

        response.Status.Should().BeEquivalentTo(responseStatus);
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Success_WithArbitraryContent_ShouldHaveNoErrors()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Success(ResponseStatus.Ok, responseContent, pageMeta);

        // Assert
        response.Errors.Should().BeEmpty();
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Success_WithComparableResponseContent_ShouldHaveCorrectContent()
    {
        // Arrange
        var responseContent = new ComparableResponseContent(10, "something");
        var pageMeta = new PageMeta();

        // Act
        var response = PagedRequestResponse<ComparableResponseContent>.Success(ResponseStatus.Ok, responseContent, pageMeta);

        // Assert
        response.Content.Should().BeOfType<ComparableResponseContent>();
        response.Content.Should().BeEquivalentTo(responseContent);
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
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
        response.IsSuccessful.Should().BeFalse();
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
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
    [Obsolete("Test kept for backwards compatibility")]
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
        response.Status.Should().BeEquivalentTo(responseStatus);
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
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
        response.Status.Should().BeEquivalentTo(responseStatus);
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Failure_WithNoErrors_ShouldHaveEmptyErrors()
    {
        // Arrange
        var responseStatus = ResponseStatus.Unauthorized;
        var errors = Array.Empty<RequestError>();

        // Act
        var response = PagedRequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        Assert.Empty(response.Errors);
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
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
