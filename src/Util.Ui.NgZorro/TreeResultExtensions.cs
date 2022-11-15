using System.Collections.Generic;
using Util.Applications.Trees;
using Util.Ui.NgZorro.Data;

namespace Util.Ui.NgZorro {
    /// <summary>
    /// NgZorro树形结果扩展
    /// </summary>
    public static class TreeResultExtensions {
        /// <summary>
        /// 转换为NgZorro树形结果
        /// </summary>
        /// <param name="nodes">树形参数列表</param>
        /// <param name="async">是否异步加载</param>
        /// <param name="allExpand">所有节点是否全部展开</param>
        public static NgZorroTreeResult ToTreeResult<TNode>( this IEnumerable<TNode> nodes, bool async = false, bool allExpand = false ) where TNode : TreeDtoBase<TNode> {
            return new TreeResult<TNode>( nodes, async, allExpand ).GetResult();
        }
    }
}
