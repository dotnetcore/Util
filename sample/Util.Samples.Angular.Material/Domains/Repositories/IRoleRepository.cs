using System;
using Util.Samples.Domains.Models;
using Util.Security.Identity.Repositories;

namespace Util.Samples.Domains.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : IRoleRepository<Role,Guid,Guid?> {
    }
}