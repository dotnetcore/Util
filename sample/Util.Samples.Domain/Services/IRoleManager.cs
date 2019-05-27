using System.Threading.Tasks;
using Util.Domains.Services;
using Util.Samples.Domain.Models;

namespace Util.Samples.Domain.Services {
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleManager : IDomainService {
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role">角色</param>
        Task CreateAsync( Role role );
        /// <summary>
        /// 修改角色
        /// </summary>
        Task UpdateAsync( Role role );
    }
}
