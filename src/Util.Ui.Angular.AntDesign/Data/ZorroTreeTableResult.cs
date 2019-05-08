using System.Collections.Generic;

namespace Util.Ui.Data {
    /// <summary>
    /// Ng-Zorro树形表格结果数据
    /// </summary>
    public class ZorroTreeTableResult<TNode> : TreeDto where TNode : TreeDto {
        /// <summary>
        /// 初始化树形表格结果数据
        /// </summary>
        public ZorroTreeTableResult() {
            Children = new List<TNode>();
        }

        /// <summary>
        /// 子节点列表
        /// </summary>
        public List<TNode> Children{ get; set; }
    }
}
