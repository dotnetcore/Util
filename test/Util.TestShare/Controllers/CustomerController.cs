using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Controllers;
using Util.Tests.Dtos;
using Util.Tests.Queries;
using Util.Tests.Services;

namespace Util.Tests.Controllers {
    /// <summary>
    /// 客户查询控制器
    /// </summary>
    public class CustomerController : QueryControllerBase<CustomerDto,CustomerQuery> {
        /// <summary>
        /// 初始化客户查询控制器
        /// </summary>
        /// <param name="service">客户服务</param>
        public CustomerController( ICustomerService service ) : base( service ) {
            CustomerService = service;
        }

        /// <summary>
        /// 客户服务
        /// </summary>
        public ICustomerService CustomerService { get; }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id">标识</param>
        [HttpGet( "{id}" )]
        public new async Task<IActionResult> GetAsync( string id ) {
            return await base.GetAsync( id );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet( "Query" )]
        public new async Task<IActionResult> QueryAsync( [FromQuery] CustomerQuery query ) {
            return await base.QueryAsync( query );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet]
        public new async Task<IActionResult> PageQueryAsync( [FromQuery] CustomerQuery query ) {
            return await base.PageQueryAsync( query );
        }

        /// <summary>
        /// 获取项列表
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet( "Items" )]
        public new async Task<IActionResult> GetItemsAsync( [FromQuery] CustomerQuery query ) {
            return await base.GetItemsAsync( query );
        }
    }
}