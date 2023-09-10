using System.Threading;

namespace Util.Security.Authorization;

/// <summary>
/// 默认权限管理器
/// </summary>
public class DefaultPermissionManager : IPermissionManager {
    /// <inheritdoc />
    public bool HasPermission( string resourceUri ) {
        return true;
    }

    /// <inheritdoc />
    public Task<bool> HasPermissionAsync( string resourceUri, CancellationToken cancellationToken = default ) {
        return Task.FromResult( true );
    }
}