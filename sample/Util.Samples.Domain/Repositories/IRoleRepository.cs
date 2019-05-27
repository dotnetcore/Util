using System;
using Util.Domains.Trees;
using Util.Samples.Domain.Models;

namespace Util.Samples.Domain.Repositories {
    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role,Guid,Guid?> {
    }
}