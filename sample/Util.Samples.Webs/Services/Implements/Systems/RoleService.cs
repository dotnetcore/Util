using System;
using System.Threading.Tasks;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Maps;
using Util.Samples.Webs.Datas;
using Util.Samples.Webs.Domains.Models;
using Util.Samples.Webs.Domains.Repositories;
using Util.Samples.Webs.Domains.Services.Abstractions;
using Util.Samples.Webs.Services.Abstractions.Systems;
using Util.Samples.Webs.Services.Dtos.Systems;
using Util.Samples.Webs.Services.Queries.Systems;

namespace Util.Samples.Webs.Services.Implements.Systems {
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService : TreeServiceBase<Role, RoleDto, RoleQuery>, IRoleService {
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="roleManager">角色服务</param>
        /// <param name="roleRepository">角色仓储</param>
        public RoleService( ISampleUnitOfWork unitOfWork, IRoleManager roleManager, IRoleRepository roleRepository ) : base( roleRepository ) {
            UnitOfWork = unitOfWork;
            RoleManager = roleManager;
            RoleRepository = roleRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public ISampleUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// 角色服务
        /// </summary>
        public IRoleManager RoleManager { get; set; }
        /// <summary>
        /// 角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建请求参数</param>
        public async Task<Guid> CreateAsync( CreateRoleRequest request ) {
            var role = ToEntity( request );
            await RoleManager.CreateAsync( role );
            await UnitOfWork.CommitAsync();
            return role.Id;
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        protected Role ToEntity( CreateRoleRequest request ) {
            return request.MapTo<Role>();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Role> CreateQuery( RoleQuery param ) {
            return new Query<Role>( param );
        }
    }
}
