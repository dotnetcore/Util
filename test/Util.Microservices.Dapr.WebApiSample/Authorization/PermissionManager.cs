using Util.Security.Authorization;

namespace Util.Microservices.Dapr.WebApiSample.Authorization; 

/// <summary>
/// 权限管理器
/// </summary>
public class PermissionManager : IPermissionManager {
    /// <summary>
    /// 是否有权限访问
    /// </summary>
    /// <param name="resourceUri">资源标识</param>
    public Task<bool> HasPermissionAsync( string resourceUri ) {
        return Task.FromResult( false );
    }
}