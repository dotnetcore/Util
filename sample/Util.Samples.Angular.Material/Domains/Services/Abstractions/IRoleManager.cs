using System;
using Util.Samples.Domains.Models;
using Util.Security.Identity.Services.Abstractions;

namespace Util.Samples.Domains.Services.Abstractions {
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleManager : IRoleManager<Role, Guid, Guid?> {
    }
}
