using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Dtos;
using Util.Applications.Properties;
using Util.Data;
using Util.Data.Queries;

namespace Util.Applications.Controllers {
    /// <summary>
    /// 查询控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>    
    public abstract class QueryControllerBase<TDto, TQuery> : WebApiControllerBase
        where TQuery : IPage
        where TDto : IDto, new() {

        #region 字段

        /// <summary>
        /// 查询服务
        /// </summary>
        private readonly IQueryService<TDto, TQuery> _service;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化查询控制器
        /// </summary>
        /// <param name="service">查询服务</param>
        protected QueryControllerBase( IQueryService<TDto, TQuery> service ) {
            _service = service;
        }

        #endregion

        #region GetAsync(获取单个实体)

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id">标识</param>
        protected async Task<IActionResult> GetAsync( string id ) {
            var result = await _service.GetByIdAsync( id );
            return Success( result );
        }

        #endregion

        #region QueryAsync(查询)

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询参数</param>
        protected async Task<IActionResult> QueryAsync( TQuery query ) {
            if ( query == null )
                return Fail( ApplicationResource.QueryIsEmpty );
            QueryBefore( query );
            var list = await _service.QueryAsync( query );
            var result = QueryAfter( list );
            return Success( result );
        }

        /// <summary>
        /// 查询前操作
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void QueryBefore( TQuery query ) {
        }

        /// <summary>
        /// 查询后操作,用于转换查询结果
        /// </summary>
        /// <param name="list">查询结果</param>
        protected virtual dynamic QueryAfter( List<TDto> list ) {
            return list;
        }

        #endregion

        #region PageQueryAsync(分页查询)

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询参数</param>
        protected async Task<IActionResult> PageQueryAsync( TQuery query ) {
            if ( query == null )
                return Fail( ApplicationResource.QueryIsEmpty );
            PageQueryBefore( query );
            var pageList = await _service.PageQueryAsync( query );
            var result = PageQueryAfter( pageList );
            return Success( result );
        }

        /// <summary>
        /// 分页查询前操作
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void PageQueryBefore( TQuery query ) {
        }

        /// <summary>
        /// 分页查询后操作,用于转换查询结果
        /// </summary>
        /// <param name="pageList">分页查询结果</param>
        protected virtual dynamic PageQueryAfter( PageList<TDto> pageList ) {
            return pageList;
        }

        #endregion

        #region GetItemsAsync(获取项列表)

        /// <summary>
        /// 获取项列表
        /// </summary>
        /// <param name="query">查询参数</param>
        protected async Task<IActionResult> GetItemsAsync( TQuery query ) {
            if ( query == null )
                return Fail( ApplicationResource.QueryIsEmpty );
            var pageList = await _service.PageQueryAsync( query );
            var result = pageList.Data.Select( dto => ToItem( dto, query ) );
            return Success( result );
        }

        /// <summary>
        /// 将Dto转换为列表项
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        /// <param name="query">查询参数</param>
        protected virtual Item ToItem( TDto dto, TQuery query ) {
            return ToItem( dto );
        }

        /// <summary>
        /// 将Dto转换为列表项
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected virtual Item ToItem( TDto dto ) {
            throw new NotImplementedException( nameof( ToItem ) );
        }

        #endregion
    }
}
