namespace Util.Applications.Trees {
    /// <summary>
    /// 加载操作
    /// </summary>
    public enum LoadOperation {
        /// <summary>
        /// 首次加载
        /// </summary>
        FirstLoad = 1,
        /// <summary>
        /// 加载子节点
        /// </summary>
        LoadChild = 2,
        /// <summary>
        /// 搜索
        /// </summary>
        Search = 3
    }
}