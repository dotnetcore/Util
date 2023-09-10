namespace Util.Tenants.Tests.Controllers;

/// <summary>
/// 测试控制器
/// </summary>
[Route( "api/test" )]
public class TestController : ControllerBase {
    /// <summary>
    /// 租户管理器
    /// </summary>
    private readonly ITenantManager _tenantManager;

    /// <summary>
    /// 初始化测试控制器
    /// </summary>
    /// <param name="tenantManager">租户管理器</param>
    public TestController( ITenantManager tenantManager ) {
        _tenantManager = tenantManager;
    }

    /// <summary>
    /// 获取当前租户标识
    /// </summary>
    [HttpGet]
    public IActionResult GetTenantIdAsync() {
        var result = _tenantManager.GetTenantId();
        return new ContentResult { Content = result };
    }
}