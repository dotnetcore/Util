using System.Collections.Generic;

namespace Util.Ui.NgZorro.Data {
    /// <summary>
    /// Ng-Zorro树形结果
    /// </summary>
    public class NgZorroTreeResult {
        /// <summary>
        /// 初始化树形结果
        /// </summary>
        public NgZorroTreeResult() {
            Nodes = new List<NgZorroTreeNode>();
            CheckedKeys = new List<string>();
            SelectedKeys = new List<string>();
        }

        /// <summary>
        /// 树节点列表
        /// </summary>
        public List<NgZorroTreeNode> Nodes { get; set; }
        /// <summary>
        /// 复选框选中节点标识列表
        /// </summary>
        public List<string> CheckedKeys { get; set; }
        /// <summary>
        /// 选中节点标识列表
        /// </summary>
        public List<string> SelectedKeys { get; set; }
    }
}
