using Util.Applications.Trees;

namespace Util.Ui.Tests.Samples {
    /// <summary>
    /// 树节点样例
    /// </summary>
    public class TreeNodeSample : ITreeNode {
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 父标识
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 级数
        /// </summary>
        public int? Level { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool? Expanded { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
