using Util.Microservices.Dapr.Tests.Fixtures;
using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.ServiceInvocations;

/// <summary>
/// 使用Http Client调用服务测试
/// 说明: 请求WebApi项目 Util.Microservices.Dapr.WebApiSample
/// </summary>
[Collection( "Global" )]
public class HttpClientTest {
    /// <summary>
    /// Http客户端操作
    /// </summary>
    private readonly IHttpClient _client;
    /// <summary>
    /// 日志
    /// </summary>
    private readonly ILogger<HttpClientTest> _logger;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public HttpClientTest( GlobalFixture fixture, IMicroserviceClientFactory factory, ILogger<HttpClientTest> logger ) {
        _client = factory.DaprHttpPort( fixture.DaprHttpPort )
            .AppId( GlobalFixture.WebApiAppId )
            .Create()
            .HttpClient;
        _logger = logger;
    }

    /// <summary>
    /// 请求Test1Controller控制器Get_1方法,返回字符串
    /// </summary>
    [Fact]
    public async Task Test_1() {
        var result = await _client.Get( "test1" ).GetResultAsync();
        _logger.LogDebug( result );
        Assert.Equal( "ok", result );
    }

    /// <summary>
    /// 请求Test1Controller控制器Get_2方法,传入id参数
    /// </summary>
    [Fact]
    public async Task Test_2() {
        var result = await _client.Get( "test1/1" ).GetResultAsync();
        _logger.LogDebug( result );
        Assert.Equal( "id:1", result );
    }

    /// <summary>
    /// 测试调用方法 - 请求Test3Controller控制器Query方法
    /// </summary>
    [Fact]
    public async Task Test_3() {
        var query = new CustomerQuery { Name = "ok" };
        var result = await _client.Get<ServiceResult<CustomerDto>>( "/api/test3/query", query ).GetResultAsync();
        Assert.NotNull( result );
        Assert.Equal( "ok", result.Data.Name );
    }
}