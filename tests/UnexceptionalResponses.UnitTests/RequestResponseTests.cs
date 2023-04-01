namespace UnexceptionalResponses.UnitTests;

public class RequestResponseTests
{
    [Fact]
    public void Ok_WithArbitraryContent_ShouldHaveTrueIsSuccessful()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse.Ok(responseContent);

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
        var response = RequestResponse.Ok(responseContent);

        // Assert
        response.Status.Should().BeEquivalentTo(expectedStatus);
    }

    [Fact]
    public void Ok_WithArbitraryContent_ShouldHaveCorrectContent()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse.Ok(responseContent);

        // Assert
        response.Content.Should().BeEquivalentTo(responseContent);
    }

    [Fact]
    public void Created_WithArbitraryContent_ShouldHaveTrueIsSuccessful()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse.Created(responseContent);

        // Assert
        response.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Created_WithArbitraryContent_ShouldHaveCorrectStatus()
    {
        // Arrange
        var expectedStatus = ResponseStatus.Created;
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse.Created(responseContent);

        // Assert
        response.Status.Should().BeEquivalentTo(expectedStatus);
    }

    [Fact]
    public void Created_WithArbitraryContent_ShouldHaveCorrectContent()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse.Created(responseContent);

        // Assert
        response.Content.Should().BeEquivalentTo(responseContent);
    }

    [Fact]
    public void Accepted_WithArbitraryContent_ShouldHaveTrueIsSuccessful()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse.Accepted(responseContent);

        // Assert
        response.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Accepted_WithArbitraryContent_ShouldHaveCorrectStatus()
    {
        // Arrange
        var expectedStatus = ResponseStatus.Accepted;
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse.Accepted(responseContent);

        // Assert
        response.Status.Should().BeEquivalentTo(expectedStatus);
    }

    [Fact]
    public void Accepted_WithArbitraryContent_ShouldHaveCorrectContent()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse.Accepted(responseContent);

        // Assert
        response.Content.Should().BeEquivalentTo(responseContent);
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Success_WithArbitraryContent_ShouldHaveTrueIsSuccessful()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse<ArbitraryResponseContent>.Success(ResponseStatus.Ok, responseContent);

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

        // Act
        var response = RequestResponse<ArbitraryResponseContent>.Success(responseStatus, responseContent);

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

        // Act
        var response = RequestResponse<ArbitraryResponseContent>.Success(responseStatus, responseContent);

        // Assert
        response.Status.Should().BeEquivalentTo(responseStatus);
    }
       
    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Success_WithArbitraryContent_ShouldHaveNoErrors()
    {
        // Arrange
        var responseContent = new ArbitraryResponseContent();

        // Act
        var response = RequestResponse<ArbitraryResponseContent>.Success(ResponseStatus.Ok, responseContent);

        // Assert
        response.Errors.Should().BeEmpty();
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Success_WithComparableResponseContent_ShouldHaveCorrectContent()
    {
        // Arrange
        var responseContent = new ComparableResponseContent(10, "something");

        // Act
        var response = RequestResponse<ComparableResponseContent>.Success(ResponseStatus.Ok, responseContent);

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
        var response = RequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

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
        var response = RequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        response.Content.Should().BeNull();
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
        var response = RequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

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
        var response = RequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

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
        var response = RequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        response.Errors.Should().BeEmpty();
    }

    [Fact]
    [Obsolete("Test kept for backwards compatibility")]
    public void Failure_WithErrors_ShouldnOTHaveEmptyErrors()
    {
        // Arrange
        var responseStatus = ResponseStatus.Unauthorized;
        var errors = new RequestError[]
        {
            new("Arbitrary message", "ArbitraryLocation"),
            new("Another arbitrary message", "AnotherLocation"),
        };

        // Act
        var response = RequestResponse<ArbitraryResponseContent>.Failure(responseStatus, errors);

        // Assert
        response.Errors.Should().NotBeEmpty();
        response.Errors.Should().BeEquivalentTo(errors);
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
