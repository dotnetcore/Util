using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Controllers;
using Util.Tests.Dtos;
using Util.Tests.Queries;
using Util.Tests.Services;

namespace Util.Tests.Controllers {
    /// <summary>
    /// 产品控制器
    /// </summary>
    public class ProductController : CrudControllerBase<ProductDto,ProductQuery> {
        /// <summary>
        /// 初始化产品控制器
        /// </summary>
        /// <param name="service">产品服务</param>
        public ProductController( IProductService service ) : base( service ) {
            ProductService = service;
        }

        /// <summary>
        /// 产品服务
        /// </summary>
        public IProductService ProductService { get; }

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
        public new async Task<IActionResult> QueryAsync( [FromQuery] ProductQuery query ) {
            return await base.QueryAsync( query );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet]
        public new async Task<IActionResult> PageQueryAsync( [FromQuery] ProductQuery query ) {
            return await base.PageQueryAsync( query );
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        [HttpPost]
        public new async Task<IActionResult> CreateAsync( ProductDto request ) {
            return await base.CreateAsync( request );
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="request">修改参数</param>
        [HttpPut( "{id?}" )]
        public new async Task<IActionResult> UpdateAsync( string id, ProductDto request ) {
            return await base.UpdateAsync( id, request );
        }

        /// <summary>
        /// 删除，注意：该方法用于删除单个实体，批量删除请使用POST提交，否则可能失败
        /// </summary>
        /// <param name="id">标识</param>
        [HttpDelete( "{id}" )]
        public new async Task<IActionResult> DeleteAsync( string id ) {
            return await base.DeleteAsync( id );
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">标识列表，多个Id用逗号分隔，范例：1,2,3</param>
        [HttpPost( "delete" )]
        public async Task<IActionResult> BatchDeleteAsync( [FromBody] string ids ) {
            return await base.DeleteAsync( ids );
        }
    }
}