using Microsoft.AspNetCore.Identity;
using Util.Domains.Services;
using Util.Security.Identity.Models;
using Util.Security.Identity.Services.Abstractions;

namespace Util.Security.Identity.Services.Implements {
    /// <summary>
    /// 角色服务
    /// </summary>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TKey">角色标识类型</typeparam>
    /// <typeparam name="TParentId">角色父标识类型</typeparam>
    public abstract class RoleManager<TRole, TKey, TParentId> : DomainServiceBase, IRoleManager<TRole, TKey, TParentId> where TRole : Role<TRole, TKey, TParentId> {
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="roleManager">Identity角色服务</param>
        protected RoleManager( RoleManager<TRole> roleManager ) {
            Manager = roleManager;
        }

        /// <summary>
        /// Identity角色服务
        /// </summary>
        protected RoleManager<TRole> Manager { get; set; }
    }
}
