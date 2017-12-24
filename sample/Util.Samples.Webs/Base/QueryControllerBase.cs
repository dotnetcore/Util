using Microsoft.AspNetCore.Mvc;
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
        /// 初始化查询控制器
        /// </summary>
        /// <param name="service">服务</param>
        protected QueryControllerBase( ICrudService<TDto, TQuery> service ) {
            Service = service;
        }

        /// <summary>
        /// 服务
        /// </summary>
        protected ICrudService<TDto, TQuery> Service { get; }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        [HttpPost( "Query" )]
        public virtual IActionResult Query( [FromBody] TQuery query ) {
            var result = Service.Query( query );
            return Success( R.Success, result );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        [HttpPost]
        public virtual IActionResult PagerQuery( [FromBody] TQuery query ) {
            var result = Service.PagerQuery( query );
            return Success( R.Success, result );
        }
    }
}
