using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Util.Applications.Trees;
using Util.Samples.Service.Dtos.Systems;
using Util.Samples.Service.Queries.Systems;
using Util.Validations.Aspects;

namespace Util.Samples.Service.Abstractions.Systems {
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleService : ITreeService<RoleDto, RoleQuery> {
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色请求参数</param>
        Task<Guid> CreateAsync( [NotNull] [Valid] CreateRoleRequest request );
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色请求参数</param>
        Task UpdateAsync( [NotNull] [Valid] UpdateRoleRequest request );
    }
}
