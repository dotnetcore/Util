using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications;
using Util.Applications.Dtos;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Webs.Properties;

namespace Util.Webs.Controllers {
    /// <summary>
    /// 查询控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>    
    public abstract partial class QueryControllerBase<TDto, TQuery> : WebApiControllerBase
        where TQuery : IQueryParameter
        where TDto : IDto, new() {
        /// <summary>
        /// 查询服务
        /// </summary>
        private readonly IQueryService<TDto, TQuery> _service;

        /// <summary>
        /// 初始化查询控制器
        /// </summary>
        /// <param name="service">查询服务</param>
        protected QueryControllerBase( IQueryService<TDto, TQuery> service ) {
            _service = service;
        }

        /// <summary>
        /// 获取单个实例
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/customer/1 
        /// </remarks>
        /// <param name="id">标识</param>
        [HttpGet( "{id}" )]
        public virtual async Task<IActionResult> GetAsync( string id ) {
            var result = await _service.GetByIdAsync( id );
            return Success( result );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/customer?name=a
        /// </remarks>
        /// <param name="query">查询参数</param>
        [HttpGet]
        public virtual async Task<IActionResult> PagerQueryAsync( TQuery query ) {
            PagerQueryBefore( query );
            var result = await _service.PagerQueryAsync( query );
            return Success( ToPagerQueryResult( result ) );
        }

        /// <summary>
        /// 分页查询前操作
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void PagerQueryBefore( TQuery query ) {
        }

        /// <summary>
        /// 转换分页查询结果
        /// </summary>
        /// <param name="result">分页查询结果</param>
        protected virtual dynamic ToPagerQueryResult( PagerList<TDto> result ) {
            return result;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/customer/query?name=a
        /// </remarks>
        /// <param name="query">查询参数</param>
        [HttpGet( "Query" )]
        public virtual async Task<IActionResult> QueryAsync( TQuery query ) {
            QueryBefore( query );
            var result = await _service.QueryAsync( query );
            return Success( ToQueryResult( result ) );
        }

        /// <summary>
        /// 查询前操作
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void QueryBefore( TQuery query ) {
        }

        /// <summary>
        /// 转换查询结果
        /// </summary>
        /// <param name="result">查询结果</param>
        protected virtual dynamic ToQueryResult( List<TDto> result ) {
            return result;
        }

        /// <summary>
        /// 获取项列表
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet( "Items" )]
        public virtual async Task<IActionResult> GetItemsAsync( TQuery query ) {
            if( query == null )
                return Fail( WebResource.QueryIsEmpty );
            if( query.Order.IsEmpty() )
                query.Order = "CreationTime Desc";
            var list = await _service.PagerQueryAsync( query );
            var result = list.Data.Select( ToItem );
            return Success( result );
        }

        /// <summary>
        /// 将Dto转换为列表项
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected virtual Item ToItem( TDto dto ) {
            throw new NotImplementedException( "ToItem方法未实现,请重写控制器 ToItem 方法" );
        }
    }
}
