using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Util.Applications;
using Util.Applications.Dtos;
using Util.Datas.Queries;
using Util.Properties;
using Util.Webs.Controllers;

namespace Util.Samples.Webs.Base {
    /// <summary>
    /// 查询控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询实体类型</typeparam>    
    public abstract class QueryControllerBase<TDto, TQuery> : WebApiControllerBase
        where TQuery : IQueryParameter
        where TDto : class, IDto, new() {
        /// <summary>
        /// Crud服务
        /// </summary>
        private readonly ICrudService<TDto, TQuery> _service;

        /// <summary>
        /// 初始化查询控制器
        /// </summary>
        /// <param name="service">Crud服务</param>
        protected QueryControllerBase( ICrudService<TDto, TQuery> service ) {
            _service = service;
        }

        /// <summary>
        /// 获取单个实例,调用范例：GET URL(/api/customers/1)
        /// </summary>
        /// <param name="id">标识</param>
        [HttpGet( "{id}" )]
        public virtual async Task<IActionResult> GetAsync( string id ) {
            var result = await _service.GetByIdAsync( id );
            return Success( R.Success, result );
        }

        /// <summary>
        /// 查询,调用范例：GET URL(/api/customers/query?name=a)
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet( "Query" )]
        public virtual async Task<IActionResult> QueryAsync( TQuery query ) {
            var result = await _service.QueryAsync( query );
            return Success( R.Success, result );
        }

        /// <summary>
        /// 分页查询,调用范例：GET URL(/api/customers?name=a)
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet]
        public virtual async Task<IActionResult> PagerQueryAsync( TQuery query ) {
            var result = await _service.PagerQueryAsync( query );
            return Success( R.Success, result );
        }
    }
}
