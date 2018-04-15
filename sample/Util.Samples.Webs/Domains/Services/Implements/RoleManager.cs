using System;
using Microsoft.AspNetCore.Identity;
using Util.Samples.Webs.Domains.Models;
using Util.Samples.Webs.Domains.Repositories;
using Util.Samples.Webs.Domains.Services.Abstractions;
using Util.Security.Identity.Services.Implements;

namespace Util.Samples.Webs.Domains.Services.Implements {
    /// <summary>
    /// 初始化角色服务
    /// </summary>
    public class RoleManager : RoleManager<Role, Guid, Guid?>, IRoleManager {
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="roleManager">Identity角色服务</param>
        /// <param name="roleRepository">角色仓储</param>
        public RoleManager( RoleManager<Role> roleManager, IRoleRepository roleRepository ) : base( roleManager, roleRepository ) {
            Manager = roleManager;
            RoleRepository = roleRepository;
        }

        /// <summary>
        /// Identity角色服务
        /// </summary>
        protected RoleManager<Role> Manager { get; set; }
        /// <summary>
        /// 角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }
    }
}
