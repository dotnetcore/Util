using Util.Dependency;

namespace Util.Sessions; 

/// <summary>
/// 用户会话
/// </summary>
public interface ISession : ISingletonDependency {
    /// <summary>
    /// 服务提供器
    /// </summary>
    IServiceProvider ServiceProvider { get; }
    /// <summary>
    /// 是否认证
    /// </summary>
    bool IsAuthenticated { get; }
    /// <summary>
    /// 用户标识
    /// </summary>
    string UserId { get; }
    /// <summary>
    /// 租户标识
    /// </summary>
    string TenantId { get; }
}