using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Applications.Properties;
using Util.Data;
using Util.Data.Trees;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形查询操作
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeQueryActionBase<TDto, TQuery>
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {

        #region 字段

        /// <summary>
        /// 查询服务
        /// </summary>
        private readonly ITreeQueryService<TDto, TQuery> _service;
        /// <summary>
        /// 加载模式
        /// </summary>
        private readonly LoadMode _loadMode;
        /// <summary>
        /// 加载操作
        /// </summary>
        private readonly LoadOperation _loadOperation;
        /// <summary>
        /// 最大分页大小
        /// </summary>
        private readonly int _maxPageSize;
        /// <summary>
        /// 是否首次加载
        /// </summary>
        private readonly bool _isFirstLoad;
        /// <summary>
        /// 是否展开所有节点
        /// </summary>
        private readonly bool _isExpandAll;
        /// <summary>
        /// 根节点异步加载模式是否展开子节点列表
        /// </summary>
        private readonly bool _isExpandForRootAsync;
        /// <summary>
        /// 需要加载的标识列表
        /// </summary>
        private readonly string _loadKeys;
        /// <summary>
        /// 查询前操作
        /// </summary>
        private readonly Action<TQuery> _queryBefore;
        /// <summary>
        /// 数据处理操作
        /// </summary>
        private readonly Action<PageList<TDto>, TQuery> _queryAfter;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化树形查询操作
        /// </summary>
        /// <param name="service">查询服务</param>
        /// <param name="loadMode">加载模式</param>
        /// <param name="loadOperation">加载操作</param>
        /// <param name="maxPageSize">最大分页大小</param>
        /// <param name="isFirstLoad">是否首次加载</param>
        /// <param name="isExpandAll">是否展开所有节点</param>
        /// <param name="isExpandForRootAsync">根节点异步加载模式是否展开子节点列表</param>
        /// <param name="loadKeys">需要加载的标识列表</param>
        /// <param name="queryBefore">查询前操作</param>
        /// <param name="queryAfter">查询后操作</param>
        protected TreeQueryActionBase( ITreeQueryService<TDto, TQuery> service, LoadMode loadMode, LoadOperation loadOperation,
            int maxPageSize, bool isFirstLoad, bool isExpandAll, bool isExpandForRootAsync,string loadKeys,
            Action<TQuery> queryBefore, Action<PageList<TDto>, TQuery> queryAfter ) {
            _service = service ?? throw new ArgumentNullException( nameof( service ) );
            _loadMode = loadMode;
            _loadOperation = loadOperation;
            _maxPageSize = maxPageSize;
            _isFirstLoad = isFirstLoad;
            _isExpandAll = isExpandAll;
            _isExpandForRootAsync = isExpandForRootAsync;
            _loadKeys = loadKeys;
            _queryBefore = queryBefore;
            _queryAfter = queryAfter;
        }

        #endregion

        #region QueryAsync

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询参数</param>
        public async Task<dynamic> QueryAsync( TQuery query ) {
            query.CheckNull( nameof( query ) );
            _queryBefore?.Invoke( query );
            InitQueryParam( query );
            return await GetQueryResult( query );
        }

        /// <summary>
        /// 初始化查询参数
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void InitQueryParam( TQuery query ) {
            if ( query.Order.IsEmpty() )
                query.Order = "SortId";
            query.Path = null;
            if ( _loadOperation == LoadOperation.LoadChildren )
                return;
            query.ParentId = null;
        }

        /// <summary>
        /// 获取查询结果
        /// </summary>
        protected virtual async Task<dynamic> GetQueryResult( TQuery query ) {
            if ( _loadOperation == LoadOperation.LoadChildren )
                return await LoadChildren( query );
            return await LoadQuery( query );
        }

        #endregion

        #region SyncQuery

        /// <summary>
        /// 同步查询
        /// </summary>
        protected virtual async Task<PageList<TDto>> SyncQuery( TQuery query ) {
            query.PageSize = _maxPageSize;
            return await _service.PageQueryAsync( query );
        }

        #endregion

        #region AsyncQuery

        /// <summary>
        /// 异步查询
        /// </summary>
        protected virtual async Task<PageList<TDto>> AsyncQuery( TQuery query ) {
            return await _service.PageQueryAsync( query );
        }

        #endregion

        #region ToResult

        /// <summary>
        /// 转换为树形结果
        /// </summary>
        /// <param name="data">数据列表</param>
        /// <param name="async">是否异步加载</param>
        /// <param name="allExpand">所有节点是否全部展开</param>
        protected abstract dynamic ToResult( PageList<TDto> data, bool async = false, bool allExpand = false );

        #endregion

        #region LoadChildren

        /// <summary>
        /// 加载子节点列表
        /// </summary>
        protected virtual async Task<dynamic> LoadChildren( TQuery query ) {
            if ( query.ParentId.IsEmpty() )
                throw new InvalidOperationException( ApplicationResource.ParentIdIsEmpty );
            query.Page = 1;
            if ( _loadMode == LoadMode.RootAsync )
                return await SyncLoadChildren( query );
            return await AsyncLoadChildren( query );
        }

        /// <summary>
        /// 同步加载子节点列表 - 用于根节点异步加载模式
        /// </summary>
        protected virtual async Task<dynamic> SyncLoadChildren( TQuery query ) {
            var parentId = query.ParentId.SafeString();
            var queryParam = await InitSyncLoadChildrenQuery( query );
            var data = await SyncQuery( queryParam );
            data.Total -= 1;
            data.Data.RemoveAll( t => t.Id == parentId );
            _queryAfter?.Invoke( data, query );
            return ToResult( data, false, _isExpandForRootAsync );
        }

        /// <summary>
        /// 初始化同步加载子节点查询参数
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual async Task<TQuery> InitSyncLoadChildrenQuery( TQuery query ) {
            var parent = await _service.GetByIdAsync( query.ParentId );
            query.Path = parent.Path;
            query.Level = null;
            query.ParentId = null;
            return query;
        }

        /// <summary>
        /// 异步加载子节点列表
        /// </summary>
        protected virtual async Task<dynamic> AsyncLoadChildren( TQuery query ) {
            var queryParam = await InitAsyncLoadChildrenQuery( query );
            var data = await SyncQuery( queryParam );
            _queryAfter?.Invoke( data, query );
            return ToResult( data, true, _isExpandAll );
        }

        /// <summary>
        /// 初始化异步加载子节点查询参数
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual Task<TQuery> InitAsyncLoadChildrenQuery( TQuery query ) {
            query.Level = null;
            query.Path = null;
            return Task.FromResult( query );
        }

        #endregion

        #region LoadQuery

        /// <summary>
        /// 加载查询结果
        /// </summary>
        protected virtual async Task<dynamic> LoadQuery( TQuery query ) {
            if ( _loadMode == LoadMode.Sync )
                return await SyncLoadQuery( query );
            return await AsyncLoadQuery( query );
        }

        /// <summary>
        /// 同步查询
        /// </summary>
        protected virtual async Task<dynamic> SyncLoadQuery( TQuery query ) {
            var data = await SyncQuery( query );
            await AddMissingParents( data );
            _queryAfter?.Invoke( data, query );
            return ToResult( data, false, _isExpandAll );
        }

        /// <summary>
        /// 添加缺失的父节点
        /// </summary>
        protected virtual async Task AddMissingParents( PageList<TDto> data ) {
            if ( data.Data.Any( t => t.Level > 1 ) == false )
                return;
            var ids = data.Data.GetMissingParentIds();
            var list = await _service.GetByIdsAsync( ids.Join() );
            data.Data.AddRange( list.DistinctBy( t => t.Id ) );
        }

        /// <summary>
        /// 异步查询
        /// </summary>
        protected virtual async Task<dynamic> AsyncLoadQuery( TQuery query ) {
            if ( _isFirstLoad )
                return await AsyncFirstLoadQuery( query );
            query.PageSize = _maxPageSize;
            var data = await AsyncQuery( query );
            await AddMissingParents( data );
            _queryAfter?.Invoke( data, query );
            return ToResult( data, true, _isExpandAll );
        }

        /// <summary>
        /// 异步首次加载
        /// </summary>
        protected virtual async Task<dynamic> AsyncFirstLoadQuery( TQuery query ) {
            query.Level = 1;
            var data = await AsyncQuery( query );
            if ( _loadKeys.IsEmpty() == false ) {
                var parentIds = await GetLoadParentIds( _loadKeys );
                var nodes = await GetLoadNodes( parentIds.Join() );
                data.Data.AddRange( nodes );
                ExpandParentNodes( data, parentIds );
            }
            _queryAfter?.Invoke( data, query );
            return ToResult( data, true, _isExpandAll );
        }

        /// <summary>
        /// 获取需要加载的父标识列表
        /// </summary>
        protected virtual async Task<List<string>> GetLoadParentIds( string keys ) {
            var result = new List<string>();
            var selectedNodes = await _service.GetByIdsAsync( keys );
            selectedNodes.ForEach( t => result.AddRange( t.GetParentIdsFromPath( false ) ) );
            return result;
        }

        /// <summary>
        /// 根据父标识列表加载节点
        /// </summary>
        protected virtual async Task<List<TDto>> GetLoadNodes( string parentIds ) {
            return await _service.GetByParentIds( parentIds );
        }

        /// <summary>
        /// 展开父节点
        /// </summary>
        protected virtual void ExpandParentNodes( PageList<TDto> data, List<string> parentIds ) {
            var nodes = data.Data.FindAll( node => parentIds.Any( id => node.Id == id ) );
            nodes.ForEach( t => t.Expanded = true );
        }

        #endregion
    }
}
