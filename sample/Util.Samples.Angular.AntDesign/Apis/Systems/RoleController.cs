using Util.Samples.Service.Abstractions.Systems;
using Util.Samples.Service.Dtos.Systems;
using Util.Samples.Service.Queries.Systems;
using Util.Ui.Controllers;

namespace Util.Samples.Apis.Systems {
    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleController : TreeControllerBase<RoleDto, RoleQuery> {
        /// <summary>
        /// 初始化角色控制器
        /// </summary>
        /// <param name="service">角色服务</param>
        public RoleController( IRoleService service ) : base( service ) {
        }
    }

    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleTableController : TreeTableControllerBase<RoleDto, RoleQuery> {
        /// <summary>
        /// 初始化角色控制器
        /// </summary>
        /// <param name="service">角色服务</param>
        public RoleTableController( IRoleService service ) : base( service ) {
        }
    }
}