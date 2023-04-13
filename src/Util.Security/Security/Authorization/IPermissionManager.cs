using System.Threading.Tasks;

namespace Util.Security.Authorization {
    /// <summary>
    /// 权限管理器
    /// </summary>
    public interface IPermissionManager {
        /// <summary>
        /// 检查当前用户是否具有该资源的访问权限,返回true表示允许访问,false表示拒绝访问
        /// </summary>
        /// <param name="resourceUri">资源标识</param>
        Task<bool> HasPermissionAsync( string resourceUri );
    }
}
