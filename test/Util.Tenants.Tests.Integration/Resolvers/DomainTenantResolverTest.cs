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
    /// 测试初始化
    /// </summary>
    public DomainTenantResolverTest( IHttpClient client ) {
        _client = client;
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
}