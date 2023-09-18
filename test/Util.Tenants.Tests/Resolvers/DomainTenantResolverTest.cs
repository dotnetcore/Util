using Util.Helpers;
using Util.Tenants.Resolvers;

namespace Util.Tenants.Tests.Resolvers;

/// <summary>
/// 域名租户解析器测试
/// </summary>
public class DomainTenantResolverTest {
    /// <summary>
    /// 域名租户解析器
    /// </summary>
    private DomainTenantResolver _resolver;
    /// <summary>
    /// 模拟Http上下文
    /// </summary>
    private readonly Mock<HttpContext> _mockHttpContext;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public DomainTenantResolverTest() {
        _resolver = new DomainTenantResolver();
        _mockHttpContext = new Mock<HttpContext>();
    }

    /// <summary>
    /// 测试解析租户标识 - 默认解析 - 2级域名
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_1() {
        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "http://a.test.com" ) );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( Ioc.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 默认解析 - 顶级域名
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_2() {
        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "http://test.com" ) );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( Ioc.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Null( result );
    }

    /// <summary>
    /// 测试解析租户标识 - 默认解析 - 3级域名
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_3() {
        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "https://a.b.test.com" ) );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( Ioc.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 指定域名格式
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_4() {
        //传入域名格式
        _resolver = new DomainTenantResolver( "b.{0}.test.com" );

        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "https://b.a.test.com" ) );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( Ioc.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 指定域名格式 - http前缀
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_5() {
        //传入域名格式
        _resolver = new DomainTenantResolver( "http://b.{0}.test.com" );

        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "https://b.a.test.com" ) );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( Ioc.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 指定多个域名格式 - 逗号分隔
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_6() {
        //传入域名格式
        _resolver = new DomainTenantResolver( "b.{0}.test.com,{0}.test.com" );

        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "https://b.a.test.com" ) );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( Ioc.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 指定多个域名格式 - 分号分隔
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_7() {
        //传入域名格式
        _resolver = new DomainTenantResolver( "http://b.{0}.test.com;;https://{0}.test.com" );

        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "https://b.a.test.com" ) );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( Ioc.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 域名映射配置
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_8() {
        //传入域名格式
        var map = new Dictionary<string, string> {
            {"a.test.com","b"}
        };
        _resolver = new DomainTenantResolver( map );

        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "https://a.test.com" ) );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( Ioc.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "b", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 租户域名存储器
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_9() {
        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "https://a.test.com" ) );

        //设置租户域名存储器
        var mockResolver = new Mock<ITenantDomainStore>();
        mockResolver.Setup( t => t.GetAsync() ).ReturnsAsync( new Dictionary<string, string>{{ "a.test.com", "b" } } );
        var container = Ioc.CreateContainer();
        container.GetServices().AddTransient( _ => mockResolver.Object );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( container.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "b", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 租户域名存储器 - 合并设置
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_10() {
        //传入域名格式
        var map = new Dictionary<string, string> {
            {"a.test.com","b"}
        };
        _resolver = new DomainTenantResolver( map );

        //设置主机名
        _mockHttpContext.Setup( t => t.Request.Host ).Returns( new HostString( "https://a.test.com" ) );

        //设置租户域名存储器
        var mockResolver = new Mock<ITenantDomainStore>();
        mockResolver.Setup( t => t.GetAsync() ).ReturnsAsync( new Dictionary<string, string> { { "c.test.com", "c" } } );
        var container = Ioc.CreateContainer();
        container.GetServices().AddTransient( _ => mockResolver.Object );
        _mockHttpContext.Setup( t => t.RequestServices ).Returns( container.GetServiceProvider() );

        //执行
        var result = await _resolver.ResolveAsync( _mockHttpContext.Object );

        //验证
        Assert.Equal( "b", result );
    }
}