using Microsoft.Extensions.Primitives;
using Util.Helpers;
using Util.Tenants.Resolvers;

namespace Util.Tenants.Tests.Resolvers;

/// <summary>
/// 请求头租户解析器测试
/// </summary>
public class HeaderTenantResolverTest {
    /// <summary>
    /// 请求头租户解析器
    /// </summary>
    private readonly HeaderTenantResolver _resolver;
    /// <summary>
    /// 模拟Http上下文
    /// </summary>
    private readonly Mock<HttpContext> _mockHttpContext;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public HeaderTenantResolverTest() {
        _resolver = new HeaderTenantResolver();
        _mockHttpContext = new Mock<HttpContext>();
    }

    /// <summary>
    /// 测试解析租户标识 - 默认租户键名
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_1() {
        //设置请求头
        var headers = new Dictionary<string, StringValues> {
            { TenantOptions.DefaultTenantKey,"a" }
        };
        _mockHttpContext.Setup( t => t.Request.Headers ).Returns( new HeaderDictionary( headers ) );

        //设置租户配置
        var container = Ioc.CreateContainer();
        container.GetServices().Configure<TenantOptions>( t => t.IsEnabled = true );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( container.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 指定租户键名
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_2() {
        //设置请求头
        var headers = new Dictionary<string, StringValues> {
            { "key","a" }
        };
        _mockHttpContext.Setup( t => t.Request.Headers ).Returns( new HeaderDictionary( headers ) );

        //设置租户键名
        var container = Ioc.CreateContainer();
        container.GetServices().Configure<TenantOptions>( t => t.TenantKey = "key" );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( container.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "a", result );
    }
}