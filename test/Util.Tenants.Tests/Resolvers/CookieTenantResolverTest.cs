using Util.Helpers;
using Util.Tenants.Resolvers;

namespace Util.Tenants.Tests.Resolvers;

/// <summary>
/// Cookie租户解析器测试
/// </summary>
public class CookieTenantResolverTest {
    /// <summary>
    /// Cookie租户解析器
    /// </summary>
    private readonly CookieTenantResolver _resolver;
    /// <summary>
    /// 模拟Http上下文
    /// </summary>
    private readonly Mock<HttpContext> _mockHttpContext;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public CookieTenantResolverTest() {
        _resolver = new CookieTenantResolver();
        _mockHttpContext = new Mock<HttpContext>();
    }

    /// <summary>
    /// 测试解析租户标识 - 默认租户键名
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_1() {
        //设置Cookie
        var mockCookies = new Mock<IRequestCookieCollection>();
        mockCookies.Setup( t => t[TenantOptions.DefaultTenantKey] ).Returns( "a" );
        _mockHttpContext.Setup( t => t.Request.Cookies ).Returns( mockCookies.Object );

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
        //设置Cookie
        var mockCookies = new Mock<IRequestCookieCollection>();
        mockCookies.Setup( t => t["key"] ).Returns( "a" );
        _mockHttpContext.Setup( t => t.Request.Cookies ).Returns( mockCookies.Object );

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