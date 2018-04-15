using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Domains.Repositories;
using Util.Samples.Webs.Services.Abstractions.Systems;
using Util.Samples.Webs.Services.Dtos.Systems;
using Util.Samples.Webs.Services.Queries.Systems;
using Util.Ui.Extensions;
using Util.Ui.Prime.TreeTables.Datas;
using Util.Webs.Controllers;

namespace Util.Samples.Webs.Apis.Systems {
    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleController : QueryControllerBase<RoleDto, RoleQuery> {
        /// <summary>
        /// 初始化角色控制器
        /// </summary>
        /// <param name="service">角色服务</param>
        public RoleController( IRoleService service ) : base( service ) {
            RoleService = service;
        }

        /// <summary>
        /// 角色服务
        /// </summary>
        public IRoleService RoleService { get; }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色请求参数</param>
        [HttpPost]
        public async Task<IActionResult> CreateAsync( [FromBody]CreateRoleRequest request ) {
            var id = await RoleService.CreateAsync( request );
            return Success( id );
        }

        /// <summary>
        /// 转换为Prime树节点列表
        /// </summary>
        protected override dynamic ToPagerQueryResult( PagerList<RoleDto> result ) {
            var treeNodes = result.Data.ToPrimeResult();
            return new PagerList<PrimeTreeNode<RoleDto>>( result.Page, result.PageSize, result.TotalCount, result.Order,treeNodes );
        }
    }
}