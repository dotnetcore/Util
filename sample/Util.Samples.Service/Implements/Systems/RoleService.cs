using System;
using System.Threading.Tasks;
using Util.Applications.Trees;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Maps;
using Util.Samples.Data;
using Util.Samples.Domain.Models;
using Util.Samples.Domain.Repositories;
using Util.Samples.Domain.Services;
using Util.Samples.Service.Abstractions.Systems;
using Util.Samples.Service.Dtos.Systems;
using Util.Samples.Service.Queries.Systems;

namespace Util.Samples.Service.Implements.Systems {
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
        public RoleService( ISampleUnitOfWork unitOfWork, IRoleManager roleManager,IRoleRepository roleRepository )
            : base( unitOfWork, roleRepository ) {
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
            role.Type = "Role";
            await RoleManager.CreateAsync( role );
            await UnitOfWork.CommitAsync();
            return role.Id;
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        private Role ToEntity( CreateRoleRequest request ) {
            return request.MapTo<Role>();
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色请求参数</param>
        public async Task UpdateAsync( UpdateRoleRequest request ) {
            var entity = await RoleRepository.FindAsync( request.Id.ToGuid() );
            request.MapTo( entity );
            await RoleManager.UpdateAsync( entity );
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Role> CreateQuery( RoleQuery param ) {
            return new Query<Role>( param )
                .Or( t => t.Name.Contains( param.Keyword ),
                    t => t.Code.Contains( param.Keyword ),
                    t => t.PinYin.Contains( param.Keyword ) );
        }
    }
}