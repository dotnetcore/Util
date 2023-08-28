namespace Util.Security.Authorization;

/// <summary>
/// 默认权限管理器
/// </summary>
public class DefaultPermissionManager : IPermissionManager {
    /// <inheritdoc />
    public Task<bool> HasPermissionAsync( string resourceUri ) {
        return Task.FromResult( true );
    }
}