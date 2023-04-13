using Util.Dependency;

namespace Util.FileStorage {
    /// <summary>
    /// 文件名处理器工厂
    /// </summary>
    public interface IFileNameProcessorFactory : ITransientDependency {
        /// <summary>
        /// 创建文件名处理器
        /// </summary>
        /// <param name="policy">文件名处理策略</param>
        IFileNameProcessor CreateProcessor( string policy );
    }
}