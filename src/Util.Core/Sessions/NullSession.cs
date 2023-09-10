using Util.Dependency;

namespace Util.Sessions;

/// <summary>
/// 空用户会话
/// </summary>
[Ioc(-9)]
public class NullSession : ISession {
    /// <summary>
    /// 用户会话空实例
    /// </summary>
    public static readonly ISession Instance = new NullSession();

    /// <summary>
    /// 服务提供器
    /// </summary>
    public IServiceProvider ServiceProvider => null;

    /// <summary>
    /// 是否认证
    /// </summary>
    public bool IsAuthenticated => false;

    /// <inheritdoc />
    public string UserId => string.Empty;

    /// <inheritdoc />
    public string TenantId => string.Empty;
}