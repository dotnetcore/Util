using System;
using Util.Sessions;

namespace Util.Tests.Infrastructure; 

/// <summary>
/// 测试用户会话
/// </summary>
public class TestSession : ISession {
    /// <summary>
    /// 服务提供器
    /// </summary>
    public IServiceProvider ServiceProvider => null;

    public TestSession() {
        UserId = TestUserId.ToString();
    }

    public bool IsAuthenticated => true;
    public string UserId { get; set; }
    public string TenantId { get; set; }

    /// <summary>
    /// 测试用户标识
    /// </summary>
    public static Guid TestUserId = "c75521e5-e247-42b2-9115-6c3cce5c3403".ToGuid();

    /// <summary>
    /// 测试用户标识2
    /// </summary>
    public static Guid TestUserId2 = "0e81ddbc-f43c-2622-e753-4abdfdc8db06".ToGuid();
}