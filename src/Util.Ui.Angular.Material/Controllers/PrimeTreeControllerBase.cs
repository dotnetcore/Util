using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Trees;
using Util.Datas.Queries.Trees;
using Util.Domains.Repositories;
using Util.Exceptions;
using Util.Ui.Extensions;
using Util.Ui.Prime.TreeTables.Datas;
using Util.Webs.Controllers.Trees;

namespace Util.Ui.Controllers {
    /// <summary>
    /// 树形控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class PrimeTreeControllerBase<TDto, TQuery> : PrimeTreeControllerBase<TDto, TQuery, Guid?>
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter, new() {
        /// <summary>
        /// 初始化树形控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected PrimeTreeControllerBase( ITreeService<TDto, TQuery, Guid?> service ) : base( service ) {
        }
    }

    /// <summary>
    /// 树形控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class PrimeTreeControllerBase<TDto, TQuery, TParentId> : ControllerBase<TDto, TQuery, TParentId>
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter<TParentId>, new() {
        /// <summary>
        /// 树形服务
        /// </summary>
        private readonly ITreeService<TDto, TQuery, TParentId> _service;

        /// <summary>
        /// 初始化树形控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected PrimeTreeControllerBase( ITreeService<TDto, TQuery, TParentId> service ) : base( service ) {
            _service = service;
        }

        /// <summary>
        /// 获取单个树形节点
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/role/tree?id=1
        /// </remarks>
        /// <param name="id">标识</param>
        [HttpGet( "tree" )]
        public virtual async Task<IActionResult> GetTreeNodeAsync( string id ) {
            var result = await _service.GetByIdAsync( id );
            return Success( new PrimeTreeNode<TDto> { Data = result } );
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
            ProcessParam( query );
            PagerList<PrimeTreeNode<TDto>> result;
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
        /// 参数处理
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void ProcessParam( TQuery query ) {
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
            var operation = HttpContext.Request.Query["operation"].SafeString();
            if( operation.ToLower() == "loadchild" )
                return LoadOperation.LoadChild;
            if( query.IsSearch() )
                return LoadOperation.Search;
            return LoadOperation.FirstLoad;
        }

        /// <summary>
        /// 首次加载
        /// </summary>
        protected virtual async Task<PagerList<PrimeTreeNode<TDto>>> FirstLoad( TQuery query ) {
            if( GetLoadMode() == LoadMode.Sync )
                return await SyncFirstLoad( query );
            return await AsyncFirstLoad( query );
        }

        /// <summary>
        /// 同步首次加载
        /// </summary>
        protected virtual async Task<PagerList<PrimeTreeNode<TDto>>> SyncFirstLoad( TQuery query ) {
            var data = await _service.QueryAsync( query );
            return ToPagerList( data, query );
        }

        /// <summary>
        /// 转换为分页列表
        /// </summary>
        protected virtual PagerList<PrimeTreeNode<TDto>> ToPagerList( List<TDto> data, TQuery query, bool isAsync = false ) {
            var primeResult = ToPrimeResult( data,isAsync );
            query.TotalCount = primeResult.Count;
            var result = primeResult.Skip( query.GetSkipCount() ).Take( query.PageSize );
            return new PagerList<PrimeTreeNode<TDto>>( query, result );
        }

        /// <summary>
        /// 转换为树节点列表
        /// </summary>
        private List<PrimeTreeNode<TDto>> ToPrimeResult( IEnumerable<TDto> data, bool async = false ) {
            return data.ToPrimeResult( async, IsAllExpand() );
        }

        /// <summary>
        /// 所有节点是否全部展开
        /// </summary>
        protected virtual bool IsAllExpand() {
            return false;
        }

        /// <summary>
        /// 异步首次加载
        /// </summary>
        protected async Task<PagerList<PrimeTreeNode<TDto>>> AsyncFirstLoad( TQuery query ) {
            query.Level = 1;
            var result = await _service.PagerQueryAsync( query );
            return result.Convert( ToPrimeResult( result.Data,true ) );
        }

        /// <summary>
        /// 加载子节点
        /// </summary>
        protected virtual async Task<PagerList<PrimeTreeNode<TDto>>> LoadChildren( TQuery query ) {
            if( query.ParentId == null )
                throw new Warning( "父节点标识为空，加载子节点失败" );
            List<PrimeTreeNode<TDto>> result;
            if( GetLoadMode() == LoadMode.Async )
                result = await AsyncLoadChildren( query );
            else
                result = await SyncLoadChildren( query );
            return new PagerList<PrimeTreeNode<TDto>>( result );
        }

        /// <summary>
        /// 异步加载子节点
        /// </summary>
        protected virtual async Task<List<PrimeTreeNode<TDto>>> AsyncLoadChildren( TQuery query ) {
            var queryParam = await GetAsyncLoadChildrenQuery( query );
            var result = await _service.QueryAsync( queryParam );
            return ToPrimeResult( result, true );
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
        protected virtual async Task<List<PrimeTreeNode<TDto>>> SyncLoadChildren( TQuery query ) {
            var parentId = query.ParentId.SafeString();
            var queryParam = await GetSyncLoadChildrenQuery( query );
            var result = await _service.QueryAsync( queryParam );
            result.RemoveAll( t => t.Id == parentId );
            return ToPrimeResult( result );
        }

        /// <summary>
        /// 获取同步加载子节点查询参数
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual async Task<TQuery> GetSyncLoadChildrenQuery( TQuery query ) {
            var parent = await _service.GetByIdAsync( query.ParentId );
            query.Path = parent.Path;
            query.Level = null;
            query.ParentId = default(TParentId);
            return query;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        protected virtual async Task<PagerList<PrimeTreeNode<TDto>>> Search( TQuery query ) {
            var data = await _service.QueryAsync( query );
            var ids = data.GetMissingParentIds();
            var list = await _service.GetByIdsAsync( ids.Join() );
            data.AddRange( list );
            return ToPagerList( data, query, true );
        }
    }
}