using Util.Domains.Trees;
using Util.Security.Identity.Models;

namespace Util.Security.Identity.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TKey">角色标识类型</typeparam>
    /// <typeparam name="TParentId">角色父标识类型</typeparam>
    public interface IRoleRepository<TRole, in TKey, in TParentId> : ITreeRepository<TRole, TKey, TParentId> where TRole : Role<TRole,TKey, TParentId> {
    }
}