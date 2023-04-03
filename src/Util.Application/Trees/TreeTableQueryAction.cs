using System;
using Util.Data;
using Util.Data.Trees;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形表格查询操作
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public class TreeTableQueryAction<TDto, TQuery> : TreeQueryActionBase<TDto, TQuery>
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化树形表格查询操作
        /// </summary>
        /// <param name="service">查询服务</param>
        /// <param name="loadMode">加载模式</param>
        /// <param name="loadOperation">加载操作</param>
        /// <param name="maxPageSize">最大分页大小</param>
        /// <param name="isFirstLoad">是否首次加载</param>
        /// <param name="isExpandAll">是否展开所有节点</param>
        /// <param name="isExpandForRoot">根节点异步加载模式是否展开子节点列表</param>
        /// <param name="queryBefore">查询前操作</param>
        /// <param name="processData">数据处理操作</param>
        public TreeTableQueryAction( ITreeQueryService<TDto, TQuery> service, LoadMode loadMode, LoadOperation loadOperation,
            int maxPageSize, bool isFirstLoad, bool isExpandAll, bool isExpandForRoot, 
            Action<TQuery> queryBefore, Action<PageList<TDto>, TQuery> processData ) 
            : base( service, loadMode, loadOperation, maxPageSize, isFirstLoad, isExpandAll,isExpandForRoot,null, queryBefore, processData ) {
        }

        /// <summary>
        /// 转换为树形结果
        /// </summary>
        /// <param name="data">数据列表</param>
        /// <param name="async">是否异步加载</param>
        /// <param name="allExpand">所有节点是否全部展开</param>
        protected override dynamic ToResult( PageList<TDto> data, bool async = false, bool allExpand = false ) {
            return data.Convert( new TreeTableResult<TDto>( data.Data, async, allExpand ).GetResult() );
        }
    }
}
