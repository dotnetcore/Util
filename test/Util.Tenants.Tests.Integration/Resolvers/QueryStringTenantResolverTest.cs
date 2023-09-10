namespace Util.Tenants.Tests.Resolvers;

/// <summary>
/// 查询字符串租户解析器测试
/// </summary>
public class QueryStringTenantResolverTest {
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
    public QueryStringTenantResolverTest( IHttpClient client, IOptions<TenantOptions> options ) {
        _client = client;
        _options = options.Value;
    }

    /// <summary>
    /// 测试解析租户标识
    /// </summary>
    [Fact]
    public async Task TestResolveAsync() {
        var result = await _client.Get( $"/api/test?{_options.TenantKey}=a" )
            .GetResultAsync();
        Assert.Equal( "a", result );
    }
}