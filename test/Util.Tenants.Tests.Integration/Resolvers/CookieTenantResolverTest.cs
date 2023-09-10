namespace Util.Tenants.Tests.Resolvers;

/// <summary>
/// Cookie租户解析器测试
/// </summary>
public class CookieTenantResolverTest {
    /// <summary>
    /// Http客户端
    /// </summary>
    private readonly IHttpClient _client;
    /// <summary>
    /// 租户配置
    /// </summary>
    private readonly TenantOptions _options;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public CookieTenantResolverTest( IHttpClient client, IOptions<TenantOptions> options ) {
        _client = client;
        _options = options.Value;
    }

    /// <summary>
    /// 测试解析租户标识
    /// </summary>
    [Fact]
    public async Task TestResolveAsync() {
        var result = await _client.Get( "/api/test" )
            .Cookie( _options.TenantKey,"a" )
            .GetResultAsync();
        Assert.Equal( "a", result );
    }
}