namespace Util.FileStorage {
    /// <summary>
    /// 文件存储方法参数
    /// </summary>
    public class FileStorageArgs {
        /// <summary>
        /// 初始化文件存储方法参数
        /// </summary>
        /// <param name="fileName">文件名</param>
        public FileStorageArgs( string fileName ) {
            FileName = fileName;
        }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// 文件名处理策略
        /// </summary>
        public string FileNamePolicy { get; set; }

        /// <summary>
        /// 存储桶名称
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// 存储桶名称处理策略
        /// </summary>
        public string BucketNamePolicy { get; set; }
    }
}
