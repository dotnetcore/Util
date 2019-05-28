using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Trees;
using Util.Datas.Queries.Trees;
using Util.Exceptions;
using Util.Ui.Data;
using Util.Webs.Controllers.Trees;

namespace Util.Ui.Controllers {
    /// <summary>
    /// 树形控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeControllerBase<TDto, TQuery> : TreeControllerBase<TDto, TQuery, Guid?>
        where TDto : TreeDto, new()
        where TQuery : class, ITreeQueryParameter, new() {
        /// <summary>
        /// 初始化树形控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected TreeControllerBase( ITreeService<TDto, TQuery, Guid?> service ) : base( service ) {
        }
    }

    /// <summary>
    /// 树形控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeControllerBase<TDto, TQuery, TParentId> : ControllerBase<TDto, TQuery, TParentId>
        where TDto : TreeDto, new()
        where TQuery : class, ITreeQueryParameter<TParentId>, new() {
        /// <summary>
        /// 树形服务
        /// </summary>
        private readonly ITreeService<TDto, TQuery, TParentId> _service;

        /// <summary>
        /// 初始化树形控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected TreeControllerBase( ITreeService<TDto, TQuery, TParentId> service ) : base( service ) {
            _service = service;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/role?name=a
        /// </remarks>
        /// <param name="query">查询参数</param>
        [HttpGet]
        public virtual async Task<IActionResult> QueryAsync( TQuery query ) {
            if( query == null )
                throw new ArgumentNullException( nameof( query ) );
            QueryBefore( query );
            InitParam( query );
            ZorroTreeResult result;
            switch( GetOperation( query ) ) {
                case LoadOperation.FirstLoad:
                    result = await FirstLoad( query );
                    break;
                case LoadOperation.LoadChild:
                    result = await LoadChildren( query );
                    break;
                default:
                    result = await Search( query );
                    break;
            }
            return Success( result );
        }

        /// <summary>
        /// 查询前操作
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void QueryBefore( TQuery query ) {
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void InitParam( TQuery query ) {
            if( query.Order.IsEmpty() )
                query.Order = "SortId";
            query.Path = null;
            if( GetOperation( query ) == LoadOperation.LoadChild )
                return;
            query.ParentId = default( TParentId );
        }

        /// <summary>
        /// 获取操作
        /// </summary>
        protected LoadOperation? GetOperation( TQuery query ) {
            var operation = Request.Query["operation"].SafeString().ToLower();
            if( operation == "loadchild" )
                return LoadOperation.LoadChild;
            if( query.IsSearch() )
                return LoadOperation.Search;
            return LoadOperation.FirstLoad;
        }

        /// <summary>
        /// 首次加载
        /// </summary>
        protected virtual async Task<ZorroTreeResult> FirstLoad( TQuery query ) {
            if( GetLoadMode() == LoadMode.Sync )
                return await SyncFirstLoad( query );
            return await AsyncFirstLoad( query );
        }

        /// <summary>
        /// 同步首次加载
        /// </summary>
        protected virtual async Task<ZorroTreeResult> SyncFirstLoad( TQuery query ) {
            var data = await Query( query );
            return ToResult( data );
        }

        /// <summary>
        /// 查询
        /// </summary>
        private async Task<List<TDto>> Query( TQuery query ) {
            var data = await _service.QueryAsync( query );
            ProcessData( data, query );
            return data;
        }

        /// <summary>
        /// 数据处理
        /// </summary>
        /// <param name="data">数据列表</param>
        /// <param name="query">查询参数</param>
        protected virtual void ProcessData( List<TDto> data, TQuery query ) {
        }

        /// <summary>
        /// 转换为树形结果
        /// </summary>
        protected virtual ZorroTreeResult ToResult( List<TDto> data, bool async = false ) {
            return new TreeResult( data, async ).GetResult();
        }

        /// <summary>
        /// 异步首次加载
        /// </summary>
        protected virtual async Task<ZorroTreeResult> AsyncFirstLoad( TQuery query ) {
            query.Level = 1;
            var data = await Query( query );
            return ToResult( data, true );
        }

        /// <summary>
        /// 加载子节点
        /// </summary>
        protected virtual async Task<ZorroTreeResult> LoadChildren( TQuery query ) {
            if( query.ParentId == null )
                throw new Warning( "父节点标识为空，加载子节点失败" );
            if( GetLoadMode() == LoadMode.Async )
                return await AsyncLoadChildren( query );
            return await SyncLoadChildren( query );
        }

        /// <summary>
        /// 异步加载子节点
        /// </summary>
        protected virtual async Task<ZorroTreeResult> AsyncLoadChildren( TQuery query ) {
            var queryParam = await GetAsyncLoadChildrenQuery( query );
            var data = await Query( queryParam );
            return ToResult( data, true );
        }

        /// <summary>
        /// 获取异步加载子节点查询参数
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual Task<TQuery> GetAsyncLoadChildrenQuery( TQuery query ) {
            query.Level = null;
            query.Path = null;
            return Task.FromResult( query );
        }

        /// <summary>
        /// 同步加载子节点
        /// </summary>
        protected virtual async Task<ZorroTreeResult> SyncLoadChildren( TQuery query ) {
            var parentId = query.ParentId.SafeString();
            var queryParam = await GetSyncLoadChildrenQuery( query );
            var data = await _service.QueryAsync( queryParam );
            data.RemoveAll( t => t.Id == parentId );
            ProcessData( data, query );
            return ToResult( data );
        }

        /// <summary>
        /// 获取同步加载子节点查询参数
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual async Task<TQuery> GetSyncLoadChildrenQuery( TQuery query ) {
            var parent = await _service.GetByIdAsync( query.ParentId );
            query.Path = parent.Path;
            query.Level = null;
            query.ParentId = default( TParentId );
            return query;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        protected virtual async Task<ZorroTreeResult> Search( TQuery query ) {
            var data = await _service.QueryAsync( query );
            var ids = data.GetMissingParentIds();
            var list = await _service.GetByIdsAsync( ids.Join() );
            data.AddRange( list );
            ProcessData( data, query );
            if( GetLoadMode() == LoadMode.Async )
                return ToResult( data, true );
            return ToResult( data );
        }
    }
}