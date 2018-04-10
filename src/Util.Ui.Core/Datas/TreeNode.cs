namespace Util.Ui.Datas {
    /// <summary>
    /// 树节点
    /// </summary>
    public class TreeNode {
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
    }
}
