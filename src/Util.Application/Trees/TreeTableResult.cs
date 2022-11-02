using System.Collections.Generic;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形表格结果
    /// </summary>
    /// <typeparam name="TNode">节点类型</typeparam>
    public class TreeTableResult<TNode> : TreeTableResultBase<TNode,TNode, List<TNode>> where TNode : class,ITreeNode {
        /// <summary>
        /// 初始化树形表格结果
        /// </summary>
        /// <param name="data">树形参数列表</param>
        /// <param name="async">是否异步加载</param>
        /// <param name="allExpand">所有节点是否全部展开</param>
        public TreeTableResult( IEnumerable<TNode> data, bool async = false, bool allExpand = false ) : base(data,async,allExpand){
        }

        /// <summary>
        /// 转换结果
        /// </summary>
        protected override List<TNode> ToResult( List<TNode> nodes ) {
            return nodes;
        }
    }
}
