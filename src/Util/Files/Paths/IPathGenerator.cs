namespace Util.Files.Paths {
    /// <summary>
    /// 路径生成器
    /// </summary>
    public interface IPathGenerator {
        /// <summary>
        /// 生成路径
        /// </summary>
        /// <param name="fileName">文件名，必须包含扩展名，如果仅传入扩展名则生成随机文件名</param>
        string Generate( string fileName );
    }
}
