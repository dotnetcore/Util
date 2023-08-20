using Util.Microservices.Dapr.Tests.Fixtures;

namespace Util.Microservices.Dapr.Tests.ServiceInvocations;

/// <summary>
/// 服务调用测试 - Web Api接口测试
/// 说明: 请求项目 Util.Microservices.Dapr.WebApiSample
/// </summary>
[Collection( "Global" )]
public partial class ServiceInvocationTest {
    /// <summary>
    /// 服务调用操作
    /// </summary>
    private readonly IServiceInvocation _serviceInvocation;
    /// <summary>
    /// 日志
    /// </summary>
    private readonly ILogger<ServiceInvocationTest> _logger;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public ServiceInvocationTest( IServiceInvocation serviceInvocation, ILogger<ServiceInvocationTest> logger ) {
        _serviceInvocation = serviceInvocation;
        _serviceInvocation.Service( GlobalFixture.WebApiAppId );
        _logger = logger;
    }
}