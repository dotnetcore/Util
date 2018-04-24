using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications;
using Util.Applications.Dtos;
using Util.Applications.Trees;
using Util.Datas.Queries.Trees;
using Util.Domains.Repositories;
using Util.Exceptions;
using Util.Ui.Extensions;
using Util.Ui.Prime.TreeTables.Datas;
using Util.Webs.Controllers;

namespace Util.Ui.Controllers {
    /// <summary>
    /// 树型控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class PrimeTreeControllerBase<TDto, TQuery> : PrimeTreeControllerBase<TDto, TQuery, Guid?>
        where TDto : class, IResponse, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter, new() {
        /// <summary>
        /// 初始化树型控制器
        /// </summary>
        /// <param name="service">树型服务</param>
        protected PrimeTreeControllerBase( ITreeService<TDto, TQuery, Guid?> service ) : base( service ) {
        }
    }

    /// <summary>
    /// 树型控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class PrimeTreeControllerBase<TDto, TQuery, TParentId> : TreeControllerBase<TDto, TQuery, TParentId>
        where TDto : class, IResponse, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter<TParentId>, new() {
        /// <summary>
        /// 树型服务
        /// </summary>
        private readonly ITreeService<TDto, TQuery, TParentId> _service;

        /// <summary>
        /// 初始化树型控制器
        /// </summary>
        /// <param name="service">树型服务</param>
        protected PrimeTreeControllerBase( ITreeService<TDto, TQuery, TParentId> service ) : base( service ) {
            _service = service;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/customer?name=a
        /// </remarks>
        /// <param name="query">查询参数</param>
        [HttpGet]
        public virtual async Task<IActionResult> Query( TQuery query ) {
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
            query.Path = null;
            if ( GetOperation( query ) == LoadOperation.LoadChild )
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
            if ( query.IsSearch() )
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
            var primeResult = data.ToPrimeResult( isAsync );
            query.TotalCount = primeResult.Count;
            var result = primeResult.Skip( query.GetSkipCount() ).Take( query.PageSize );
            return new PagerList<PrimeTreeNode<TDto>>( query, result );
        }

        /// <summary>
        /// 异步首次加载
        /// </summary>
        protected async Task<PagerList<PrimeTreeNode<TDto>>> AsyncFirstLoad( TQuery query ) {
            query.Level = 1;
            var result = await _service.PagerQueryAsync( query );
            return result.Convert( result.Data.ToPrimeResult( true ) );
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
            var queryParam = new TQuery { ParentId = query.ParentId };
            var result = await _service.QueryAsync( queryParam );
            return result.ToPrimeResult( true );
        }

        /// <summary>
        /// 同步加载子节点
        /// </summary>
        protected virtual async Task<List<PrimeTreeNode<TDto>>> SyncLoadChildren( TQuery query ) {
            var parent = await _service.GetByIdAsync( query.ParentId );
            var queryParam = new TQuery { Path = parent.Path };
            var result = await _service.QueryAsync( queryParam );
            result.RemoveAll( t => t.Id == query.ParentId.SafeString() );
            return result.ToPrimeResult();
        }

        /// <summary>
        /// 搜索
        /// </summary>
        protected virtual async Task<PagerList<PrimeTreeNode<TDto>>> Search( TQuery query ) {
            var data = await _service.QueryAsync( query );
            AddParents( data );
            return ToPagerList( data, query, true );
        }

        /// <summary>
        /// 添加父节点
        /// </summary>
        protected void AddParents( List<TDto> result ) {
            var ids = new List<string>();
            foreach( var node in result )
                AddParentIds( ids, node );
            foreach( var node in result ) {
                if( ids.Contains( node.Id ) )
                    ids.Remove( node.Id );
            }
            var list = _service.GetByIds( ids.Join() );
            result.AddRange( list );
        }

        /// <summary>
        /// 添加父节点标识
        /// </summary>
        protected void AddParentIds( List<string> ids, TDto node ) {
            var parentIds = _service.GetParentIdsFromPath( node );
            parentIds.ForEach( id => {
                if( ids.Contains( id ) )
                    return;
                ids.Add( id );
            } );
        }
    }
}