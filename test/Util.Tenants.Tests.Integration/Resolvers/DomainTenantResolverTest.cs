namespace Util.Tenants.Tests.Resolvers;

/// <summary>
/// 域名租户解析器测试
/// </summary>
public class DomainTenantResolverTest {
    /// <summary>
    /// Http客户端
    /// </summary>
    private readonly IHttpClient _client;
    /// <summary>
    /// 域名租户解析器
    /// </summary>
    private readonly IDomainTenantResolver _resolver;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public DomainTenantResolverTest( IHttpClient client, IDomainTenantResolver resolver ) {
        _client = client;
        _resolver = resolver;
    }

    /// <summary>
    /// 测试解析租户标识
    /// </summary>
    [Fact]
    public async Task TestResolveAsync() {
        var result = await _client.Get( "http://a.test.com/api/test" )
            .GetResultAsync();
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 从域名格式解析
    /// </summary>
    [Fact]
    public async Task TestResolveTenantIdAsync_1() {
        var result = await _resolver.ResolveTenantIdAsync( "http://a1.a.test.com" );
        Assert.Equal( "a1", result );
    }

    /// <summary>
    /// 测试解析租户标识 - 从域名映射解析
    /// </summary>
    [Fact]
    public async Task TestResolveTenantIdAsync_2() {
        var result = await _resolver.ResolveTenantIdAsync( "http://b.test.com" );
        Assert.Equal( "b1", result );
    }
}