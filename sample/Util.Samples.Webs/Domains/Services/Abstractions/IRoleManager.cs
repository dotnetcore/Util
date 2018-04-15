using System;
using Util.Samples.Webs.Domains.Models;
using Util.Security.Identity.Services.Abstractions;

namespace Util.Samples.Webs.Domains.Services.Abstractions {
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleManager : IRoleManager<Role, Guid, Guid?> {
    }
}
