namespace Util.Domains.Trees {
    /// <summary>
    /// 树型物化路径
    /// </summary>
    public interface IPath {
        /// <summary>
        /// 路径
        /// </summary>
        string Path { get; }
        /// <summary>
        /// 级数
        /// </summary>
        int Level { get; }
    }
}
