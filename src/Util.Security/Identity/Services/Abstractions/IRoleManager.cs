using System.Threading.Tasks;
using Util.Domains.Services;
using Util.Security.Identity.Models;

namespace Util.Security.Identity.Services.Abstractions {
    /// <summary>
    /// 角色服务
    /// </summary>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TKey">角色标识类型</typeparam>
    /// <typeparam name="TParentId">角色父标识类型</typeparam>
    public interface IRoleManager<TRole, in TKey, TParentId> : IDomainService where TRole : Role<TRole, TKey, TParentId> {
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role">角色</param>
        Task CreateAsync( TRole role );
        /// <summary>
        /// 修改角色
        /// </summary>
        Task UpdateAsync( TRole role );
    }
}
