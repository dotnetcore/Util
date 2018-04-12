using System.Collections.Generic;
using Util.Ui.Datas;
using Util.Ui.Prime.Datas;

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
        public static List<PrimeTreeNode<TNode>> ToPrimeTreeNodes<TNode>( this IEnumerable<TNode> nodes ) where TNode : ITreeNode {
            return new PrimeTreeResult<TNode>( nodes ).GetResult();
        }
    }
}
