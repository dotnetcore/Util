using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Util.Applications.Trees;
using Util.Data.Trees;
using Util.Data;
using Util.Applications.Properties;
using Util.Applications.Dtos;

namespace Util.Applications.Controllers {
    /// <summary>
    /// 树形控制器
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeControllerBase<TDto, TQuery> : TreeControllerBase<TDto, TDto, TDto, TQuery>
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化树形控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected TreeControllerBase( ITreeService<TDto,TQuery> service ) : base(service){
        }
    }

    /// <summary>
    /// 树形控制器
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeControllerBase<TDto, TCreateRequest, TUpdateRequest, TQuery> : WebApiControllerBase
        where TDto : class, ITreeNode, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IDto, new()
        where TQuery : class, ITreeQueryParameter {

        #region 字段

        /// <summary>
        /// 树形服务
        /// </summary>
        private readonly ITreeService<TDto, TCreateRequest, TUpdateRequest, TQuery> _service;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化树形控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected TreeControllerBase( ITreeService<TDto, TCreateRequest, TUpdateRequest, TQuery> service ) {
            _service = service ?? throw new ArgumentNullException( nameof( service ) );
        }

        #endregion

        #region GetMaxPageSize(获取最大显示行数)

        /// <summary>
        /// 获取最大显示行数,默认值: 999
        /// </summary>
        protected virtual int GetMaxPageSize() {
            return 999;
        }

        #endregion

        #region GetLoadMode(获取加载模式)

        /// <summary>
        /// 获取加载模式
        /// </summary>
        protected virtual LoadMode GetLoadMode() {
            return LoadMode.Sync;
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

        #region CreateAsync(创建)

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        protected async Task<IActionResult> CreateAsync( TCreateRequest request ) {
            if ( request == null )
                return Fail( WebApiResource.CreateRequestIsEmpty );
            CreateBefore( request );
            var id = await _service.CreateAsync( request );
            var result = await _service.GetByIdAsync( id );
            return Success( result );
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        /// <param name="request">创建参数</param>
        protected virtual void CreateBefore( TCreateRequest request ) {
        }

        #endregion

        #region UpdateAsync(修改)

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="request">修改参数</param>
        protected async Task<IActionResult> UpdateAsync( string id, TUpdateRequest request ) {
            if ( request == null )
                return Fail( WebApiResource.UpdateRequestIsEmpty );
            if ( id.IsEmpty() && request.Id.IsEmpty() )
                return Fail( WebApiResource.IdIsEmpty );
            if ( request.Id.IsEmpty() )
                request.Id = id;
            UpdateBefore( request );
            await _service.UpdateAsync( request );
            var result = await _service.GetByIdAsync( request.Id );
            return Success( result );
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="dto">修改参数</param>
        protected virtual void UpdateBefore( TUpdateRequest dto ) {
        }

        #endregion

        #region DeleteAsync(删除)

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">标识列表</param>
        protected async Task<IActionResult> DeleteAsync( string ids ) {
            await _service.DeleteAsync( ids );
            return Success();
        }

        #endregion

        #region QueryAsync(查询)

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询参数</param>
        protected async Task<IActionResult> QueryAsync( TQuery query ) {
            query.CheckNull( nameof( query ) );
            QueryBefore( query );
            InitQueryParam( query );
            var result = await GetQueryResult( query );
            return Success( result );
        }

        /// <summary>
        /// 查询前操作
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void QueryBefore( TQuery query ) {
        }

        /// <summary>
        /// 初始化查询参数
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void InitQueryParam( TQuery query ) {
            if ( query.Order.IsEmpty() )
                query.Order = "SortId";
            query.Path = null;
            if ( GetOperation( query ) == LoadOperation.LoadChild )
                return;
            query.ParentId = null;
        }

        /// <summary>
        /// 获取加载操作
        /// </summary>
        protected virtual LoadOperation? GetOperation( TQuery query ) {
            return LoadOperation.FirstLoad;
        }

        /// <summary>
        /// 获取查询结果
        /// </summary>
        protected virtual async Task<dynamic> GetQueryResult( TQuery query ) {
            switch ( GetOperation( query ) ) {
                case LoadOperation.FirstLoad:
                    return await GetFirstLoadResult( query );
                case LoadOperation.LoadChild:
                    //return await LoadChildren( query );
                    break;
                default:
                    //result = await Search( query );
                    break;
            }
            return null;
        }

        /// <summary>
        /// 获取首次加载结果
        /// </summary>
        protected virtual async Task<dynamic> GetFirstLoadResult( TQuery query ) {
            if ( GetLoadMode() == LoadMode.Sync )
                return await SyncFirstLoad( query );
            return await AsyncFirstLoad( query );
        }

        /// <summary>
        /// 首次同步加载
        /// </summary>
        protected virtual async Task<dynamic> SyncFirstLoad( TQuery query ) {
            var data = await SyncQuery( query );
            ProcessData( data, query );
            return ToResult( data );
        }

        /// <summary>
        /// 同步查询
        /// </summary>
        protected virtual async Task<PageList<TDto>> SyncQuery( TQuery query ) {
            query.PageSize = GetMaxPageSize();
            return await _service.PageQueryAsync( query );
        }

        /// <summary>
        /// 数据处理
        /// </summary>
        /// <param name="data">数据列表</param>
        /// <param name="query">查询参数</param>
        protected virtual void ProcessData( PageList<TDto> data, TQuery query ) {
        }

        /// <summary>
        /// 转换为树形结果
        /// </summary>
        protected abstract dynamic ToResult( PageList<TDto> data, bool async = false );

        /// <summary>
        /// 首次异步加载
        /// </summary>
        protected virtual async Task<dynamic> AsyncFirstLoad( TQuery query ) {
            query.Level = 1;
            var data = await AsyncQuery( query );
            ProcessData( data, query );
            return ToResult( data, true );
        }

        /// <summary>
        /// 异步查询
        /// </summary>
        protected virtual async Task<PageList<TDto>> AsyncQuery( TQuery query ) {
            query.PageSize = GetMaxPageSize();
            return await _service.PageQueryAsync( query );
        }

        #endregion
    }
}
