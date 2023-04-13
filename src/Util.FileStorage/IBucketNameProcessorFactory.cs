using Util.Dependency;

namespace Util.FileStorage {
    /// <summary>
    /// 存储桶名称处理器工厂
    /// </summary>
    public interface IBucketNameProcessorFactory : ITransientDependency {
        /// <summary>
        /// 创建存储桶名称处理器
        /// </summary>
        /// <param name="policy">存储桶名称处理策略</param>
        IBucketNameProcessor CreateProcessor( string policy );
    }
}
