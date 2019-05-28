using System.Collections.Generic;

namespace Util.Ui.Data {
    /// <summary>
    /// Ng-Zorro树形结果数据
    /// </summary>
    public class ZorroTreeResult {
        /// <summary>
        /// 初始化树形结果数据
        /// </summary>
        public ZorroTreeResult() {
            Nodes = new List<ZorroTreeNode>();
            ExpandedKeys = new List<string>();
            CheckedKeys = new List<string>();
            SelectedKeys = new List<string>();
        }

        /// <summary>
        /// 树节点列表
        /// </summary>
        public List<ZorroTreeNode> Nodes { get; set; }
        /// <summary>
        /// 展开节点的标识列表
        /// </summary>
        public List<string> ExpandedKeys { get; set; }
        /// <summary>
        /// 复选框选中节点的标识列表
        /// </summary>
        public List<string> CheckedKeys { get; set; }
        /// <summary>
        /// 选中节点的标识列表
        /// </summary>
        public List<string> SelectedKeys { get; set; }
    }
}
