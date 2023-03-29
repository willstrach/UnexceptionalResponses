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
        var mediator = GetMediator();
        var result = await mediator.Send(new TestRequest());
        Assert.False(result.IsSuccessful);
        Assert.Equal(ResponseStatus.Invalid.Message, result.Status.Message);
        Assert.Equal(ResponseStatus.Invalid.StatusCode, result.Status.StatusCode);
        Assert.NotEmpty(result.Errors);
    }

    [Fact]
    public async void TestPipelineBehavour_WithPagedTestRequest_ShouldInterruptRequest()
    {
        var mediator = GetMediator();
        var result = await mediator.Send(new PagedTestRequest());
        Assert.False(result.IsSuccessful);
        Assert.Equal(ResponseStatus.Invalid.Message, result.Status.Message);
        Assert.Equal(ResponseStatus.Invalid.StatusCode, result.Status.StatusCode);
        Assert.NotEmpty(result.Errors);
    }

    class TestContent { public int IntProperty { get; set; } }
    
    class TestRequest : IRequest<RequestResponse<TestContent>>
    {
        public int IntRequestParameter { get; set; }
    }

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

    private IMediator GetMediator()
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
