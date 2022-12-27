namespace Util.Applications.Trees {
    /// <summary>
    /// 加载模式
    /// </summary>
    public enum LoadMode {
        /// <summary>
        /// 同步加载,一次性加载全部节点
        /// </summary>
        Sync = 0,
        /// <summary>
        /// 异步加载,首次加载根节点,点击仅加载直接下级节点
        /// </summary>
        Async = 1,
        /// <summary>
        /// 根节点异步加载，首次加载根节点,点击加载全部下级节点
        /// </summary>
        RootAsync = 2
    }
}