using Util.Dependency;

namespace Util.FileStorage {
    /// <summary>
    /// 文件名处理器
    /// </summary>
    public interface IFileNameProcessor : ITransientDependency {
        /// <summary>
        /// 处理文件名
        /// </summary>
        /// <param name="fileName">文件名</param>
        ProcessedName Process( string fileName );
    }
}
