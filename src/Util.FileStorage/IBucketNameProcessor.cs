namespace Util.FileStorage {
    /// <summary>
    /// 存储桶名称处理器
    /// </summary>
    public interface IBucketNameProcessor {
        /// <summary>
        /// 处理存储桶名称
        /// </summary>
        /// <param name="bucketName">存储桶名称</param>
        ProcessedName Process( string bucketName );
    }
}
