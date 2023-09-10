using Microsoft.AspNetCore.Http;

namespace Util.Tenants.Tests.Samples;

/// <summary>
/// 测试租户解析器
/// </summary>
public class TestTenantResolver : ITenantResolver {
    /// <summary>
    /// 初始化测试租户解析器
    /// </summary>
    public TestTenantResolver() {
        Priority = 1;
    }

    /// <inheritdoc />
    public Task<string> ResolveAsync( HttpContext context ) {
        return Task.FromResult( "Test" );
    }

    /// <inheritdoc />
    public int Priority { get; set; }
}

/// <summary>
/// 测试租户解析器2
/// </summary>
public class Test2TenantResolver : ITenantResolver {
    /// <summary>
    /// 初始化测试租户解析器
    /// </summary>
    public Test2TenantResolver() {
        Priority = 2;
    }

    /// <inheritdoc />
    public Task<string> ResolveAsync( HttpContext context ) {
        return Task.FromResult( "Test2" );
    }

    /// <inheritdoc />
    public int Priority { get; set; }
}

/// <summary>
/// 测试租户解析器3
/// </summary>
public class Test3TenantResolver : ITenantResolver {
    /// <summary>
    /// 初始化测试租户解析器
    /// </summary>
    public Test3TenantResolver() {
        Priority = 3;
    }

    /// <inheritdoc />
    public Task<string> ResolveAsync( HttpContext context ) {
        return Task.FromResult( "" );
    }

    /// <inheritdoc />
    public int Priority { get; set; }
}