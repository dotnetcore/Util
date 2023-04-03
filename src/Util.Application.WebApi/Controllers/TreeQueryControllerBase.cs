using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Util.Applications.Trees;
using Util.Data.Trees;
using Util.Data;

namespace Util.Applications.Controllers {
    /// <summary>
    /// 树形查询控制器
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeQueryControllerBase<TDto, TQuery> : WebApiControllerBase
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {

        #region 字段

        /// <summary>
        /// 树形服务
        /// </summary>
        private readonly ITreeQueryService<TDto, TQuery> _service;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化树形查询控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected TreeQueryControllerBase( ITreeQueryService<TDto, TQuery> service ) {
            _service = service ?? throw new ArgumentNullException( nameof( service ) );
        }

        #endregion

        #region GetMaxPageSize(获取最大分页大小 )

        /// <summary>
        /// 获取最大分页大小,默认值: 999
        /// </summary>
        protected virtual int GetMaxPageSize() {
            return 999;
        }

        #endregion

        #region GetLoadMode(获取加载模式)

        /// <summary>
        /// 获取加载模式,默认值: 同步加载模式
        /// </summary>
        protected virtual LoadMode GetLoadMode() {
            var loadMode = Request.Query["loadMode"].SafeString();
            var result = Util.Helpers.Enum.Parse<LoadMode?>( loadMode );
            if ( result != null )
                return result.Value;
            return LoadMode.Sync;
        }

        #endregion

        #region IsFirstLoad(是否首次加载)

        /// <summary>
        /// 是否首次加载
        /// </summary>
        protected virtual bool IsFirstLoad() {
            var isSearch = Request.Query["is_search"].SafeString();
            if( isSearch == "false" )
                return true;
            return false;
        }

        #endregion

        #region IsExpandAll(是否展开所有节点)

        /// <summary>
        /// 是否展开所有节点,仅对同步加载和同步查询有效
        /// </summary>
        protected virtual bool IsExpandAll() {
            var isExpandAll = Request.Query["is_expand_all"].SafeString();
            if ( isExpandAll == "true" )
                return true;
            return false;
        }

        #endregion

        #region IsExpandForRootAsync(根节点异步加载模式是否展开子节点)

        /// <summary>
        /// 根节点异步加载模式是否展开子节点,默认值: true
        /// </summary>
        protected virtual bool IsExpandForRootAsync() {
            var isExpand = Request.Query["is_expand_for_root_async"].SafeString();
            if ( isExpand == "false" )
                return false;
            return true;
        }

        #endregion

        #region GetLoadKeys(获取需要加载的标识列表)

        /// <summary>
        /// 获取需要加载的标识列表,当异步模式首次加载时,将选中节点的相关父节点加载回来,标识列表以逗号分隔
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual string GetLoadKeys( TQuery query ) {
            return Request.Query["load_keys"].SafeString();
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

        #region QueryAsync(树形表格查询)

        /// <summary>
        /// 树形表格查询
        /// </summary>
        /// <param name="query">查询参数</param>
        protected async Task<IActionResult> QueryAsync( TQuery query ) {
            var action = new TreeTableQueryAction<TDto, TQuery>( _service, GetLoadMode(), GetOperation( query ),
                GetMaxPageSize(), IsFirstLoad(), IsExpandAll(), IsExpandForRootAsync(), QueryBefore, QueryAfter );
            var result = await action.QueryAsync( query );
            return Success( result );
        }

        /// <summary>
        /// 获取加载操作
        /// </summary>
        protected virtual LoadOperation GetOperation( TQuery query ) {
            if ( query.ParentId.IsEmpty() )
                return LoadOperation.Query;
            return LoadOperation.LoadChildren;
        }

        /// <summary>
        /// 查询前操作
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void QueryBefore( TQuery query ) {
        }

        /// <summary>
        /// 查询后操作
        /// </summary>
        /// <param name="data">数据列表</param>
        /// <param name="query">查询参数</param>
        protected virtual void QueryAfter( PageList<TDto> data, TQuery query ) {
        }

        #endregion
    }
}
