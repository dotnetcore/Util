using System.Collections.Generic;
using Util.Applications.Trees;
using Util.Ui.Prime.TreeTables.Datas;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 数据和结果扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 转换为Prime树节点列表
        /// </summary>
        /// <typeparam name="TNode">节点类型</typeparam>
        /// <param name="nodes">组件实例</param>
        /// <param name="async">是否异步加载</param>
        /// <param name="allExpand">所有节点是否全部展开</param>
        public static List<PrimeTreeNode<TNode>> ToPrimeResult<TNode>( this IEnumerable<TNode> nodes, 
            bool async = false,bool allExpand = false ) where TNode : ITreeNode {
            return new PrimeTreeResult<TNode>( nodes, async, allExpand ).GetResult();
        }
    }
}
