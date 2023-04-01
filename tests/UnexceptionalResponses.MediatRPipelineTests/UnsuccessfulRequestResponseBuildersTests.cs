using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UnexceptionalResponses.MediatRPipelineTests;

public class UnsuccessfulRequestResponseBuildersTests
{
    [Fact]
    public async void TestPipelineBehavour_WithTestRequest_ShouldInterruptRequest()
    {
        // Arrange
        var mediator = GetMediator();

        // Act
        var result = await mediator.Send(new TestRequest());

        // Assert
        result.IsSuccessful.Should().BeFalse();
        result.Status.Should().BeEquivalentTo(ResponseStatus.Invalid);
        result.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public async void TestPipelineBehavour_WithPagedTestRequest_ShouldInterruptRequest()
    {
        // Arrange
        var mediator = GetMediator();

        // Act
        var result = await mediator.Send(new PagedTestRequest());

        // Assert
        result.IsSuccessful.Should().BeFalse();
        result.Status.Should().BeEquivalentTo(ResponseStatus.Invalid);
        result.Errors.Should().NotBeEmpty();
    }

    class TestContent { public int IntProperty { get; set; } }
    
    class TestRequest : IRequest<RequestResponse<TestContent>>
    {
        public int IntRequestParameter { get; set; }
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    class TestRequestHandler : IRequestHandler<TestRequest, RequestResponse<TestContent>>
    {
        public async Task<RequestResponse<TestContent>> Handle(TestRequest request, CancellationToken cancellationToken)
        {
            return RequestResponse.Ok(new TestContent());
        }
    }

    class PagedTestRequest : IRequest<PagedRequestResponse<TestContent>>
    {
        public int IntRequestParameter { get; set; }
    }

    class PagedTestRequestHandler : IRequestHandler<PagedTestRequest, PagedRequestResponse<TestContent>>
    {
        public async Task<PagedRequestResponse<TestContent>> Handle(PagedTestRequest request, CancellationToken cancellationToken)
        {
            return PagedRequestResponse.Ok(new TestContent(), new());
        }
    }
    class TestPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IRequestResponse, new()
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return CreateUnsuccessfulInstanceOf<TResponse>.WithInvalidStatus(new RequestError("A distinctive message"));
        }
    }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

    private static IMediator GetMediator()
    {
        var testServer = new TestServer(new WebHostBuilder()
            .Configure(builder =>
            {
                builder.Build();
            })
            .ConfigureServices((builder, services) =>
            {
                services.AddMediatR(configuration =>
                {
                    configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                    configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TestPipelineBehaviour<,>));
                });
            }));

        var scopeFactory = testServer.Services.GetRequiredService<IServiceScopeFactory>();
        var scope = scopeFactory.CreateScope();
        return scope.ServiceProvider.GetService<IMediator>()!;
    }
}
