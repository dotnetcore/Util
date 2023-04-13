namespace Util.FileStorage {
    /// <summary>
    /// 生成下载Url方法参数
    /// </summary>
    public class GenerateDownloadUrlArgs : FileStorageArgs {
        /// <summary>
        /// 初始化生成下载Url方法参数
        /// </summary>
        /// <param name="fileName">文件名</param>
        public GenerateDownloadUrlArgs( string fileName ) : base( fileName ) {
        }

        /// <summary>
        /// 响应内容类型
        /// </summary>
        public string ResponseContentType { get; set; }
    }
}
