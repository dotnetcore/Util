using System;
using Util.Samples.Webs.Domains.Models;
using Util.Security.Identity.Repositories;

namespace Util.Samples.Webs.Domains.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : IRoleRepository<Role,Guid,Guid?> {
    }
}