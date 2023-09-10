using ISession = Util.Sessions.ISession;

namespace Util.Tenants.Tests.Samples; 

/// <summary>
/// 测试用户会话
/// </summary>
public class TestSession : ISession {
    /// <summary>
    /// 初始化测试用户会话
    /// </summary>
    public TestSession( bool isAuthenticated, string userId, string tenantId ) {
        IsAuthenticated = isAuthenticated;
        UserId = userId;
        TenantId = tenantId;
    }

    public IServiceProvider ServiceProvider { get; }
    public bool IsAuthenticated { get; }
    public string UserId { get; }
    public string TenantId { get; }
}