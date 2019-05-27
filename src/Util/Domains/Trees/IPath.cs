namespace Util.Domains.Trees {
    /// <summary>
    /// 树形物化路径
    /// </summary>
    public interface IPath {
        /// <summary>
        /// 路径
        /// </summary>
        string Path { get; }
        /// <summary>
        /// 层级
        /// </summary>
        int Level { get; }
    }
}
