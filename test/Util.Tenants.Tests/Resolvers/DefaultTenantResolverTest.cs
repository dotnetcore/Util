using Util.Helpers;
using Util.Tenants.Resolvers;
using Util.Tenants.Tests.Samples;
using ISession = Util.Sessions.ISession;

namespace Util.Tenants.Tests.Resolvers;

/// <summary>
/// 默认租户解析器测试
/// </summary>
public class DefaultTenantResolverTest {
    /// <summary>
    /// 默认租户解析器
    /// </summary>
    private readonly DefaultTenantResolver _resolver;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public DefaultTenantResolverTest() {
        _resolver = new DefaultTenantResolver( GetMockOptions().Object );
    }

    /// <summary>
    /// 获取模拟配置
    /// </summary>
    private Mock<IOptions<TenantOptions>> GetMockOptions( bool isEnabled = true ) {
        var mockOptions = new Mock<IOptions<TenantOptions>>();
        var options = new TenantOptions {
            IsEnabled = isEnabled
        };
        options.Resolvers.Clear();
        options.Resolvers.Add( new TestTenantResolver() );
        options.Resolvers.Add( new Test2TenantResolver() );
        options.Resolvers.Add( new Test3TenantResolver() );
        mockOptions.Setup( t => t.Value ).Returns( options );
        return mockOptions;
    }

    /// <summary>
    /// 测试解析租户标识 - Test3TenantResolver优先级最高,但返回空字符串,Test2TenantResolver的优先级次之,TestTenantResolver不执行
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_1() {
        //创建模拟用户会话
        var mockSession = new Mock<ISession>();
        mockSession.Setup( t => t.IsAuthenticated ).Returns( false );
        mockSession.Setup( t => t.TenantId ).Returns( "a" );

        //创建模拟Http上下文
        var container = Ioc.CreateContainer();
        var services = container.GetServices();
        services.AddTransient( _ => mockSession.Object );
        var mockHttpContext = new Mock<HttpContext>();
        mockHttpContext.Setup( t => t.RequestServices ).Returns( container.GetServiceProvider() );

        //执行并验证
        var result = await _resolver.ResolveAsync( mockHttpContext.Object );
        Assert.Equal( "Test2", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 未启用租户,返回空
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_2() {
        //禁用租户
        var resolver = new DefaultTenantResolver( GetMockOptions( false ).Object );

        //创建模拟用户会话
        var mockSession = new Mock<ISession>();
        mockSession.Setup( t => t.IsAuthenticated ).Returns( false );
        mockSession.Setup( t => t.TenantId ).Returns( "a" );

        //创建模拟Http上下文
        var container = Ioc.CreateContainer();
        var services = container.GetServices();
        services.AddTransient( _ => mockSession.Object );
        var mockHttpContext = new Mock<HttpContext>();
        mockHttpContext.Setup( t => t.RequestServices ).Returns( container.GetServiceProvider() );

        //执行并验证
        var result = await resolver.ResolveAsync( mockHttpContext.Object );
        Assert.Null( result );
    }

    /// <summary>
    /// 测试解析租户标识 - 用户已登录,返回用户租户标识
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_3() {
        //创建模拟用户会话
        var mockSession = new Mock<ISession>();
        mockSession.Setup( t => t.IsAuthenticated ).Returns( true );
        mockSession.Setup( t => t.TenantId ).Returns( "a" );

        //创建模拟Http上下文
        var container = Ioc.CreateContainer();
        var services = container.GetServices();
        services.AddTransient( _ => mockSession.Object );
        var mockHttpContext = new Mock<HttpContext>();
        mockHttpContext.Setup( t => t.RequestServices ).Returns( container.GetServiceProvider() );

        //执行并验证
        var result = await _resolver.ResolveAsync( mockHttpContext.Object );
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 用户已登录,返回用户租户标识 - 租户标识为空
    /// </summary>
    [Fact]
    public async Task TestResolveAsync_4() {
        //创建模拟用户会话
        var mockSession = new Mock<ISession>();
        mockSession.Setup( t => t.IsAuthenticated ).Returns( true );
        mockSession.Setup( t => t.TenantId ).Returns( string.Empty );

        //创建模拟Http上下文
        var container = Ioc.CreateContainer();
        var services = container.GetServices();
        services.AddTransient( _ => mockSession.Object );
        var mockHttpContext = new Mock<HttpContext>();
        mockHttpContext.Setup( t => t.RequestServices ).Returns( container.GetServiceProvider() );

        //执行并验证
        var result = await _resolver.ResolveAsync( mockHttpContext.Object );
        Assert.Equal( string.Empty, result );
    }
}