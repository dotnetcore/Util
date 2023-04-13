namespace Util.FileStorage {
    /// <summary>
    /// 生成上传Url方法参数
    /// </summary>
    public class GenerateUploadUrlArgs : FileStorageArgs {
        /// <summary>
        /// 初始化生成上传Url方法参数
        /// </summary>
        /// <param name="fileName">文件名</param>
        public GenerateUploadUrlArgs( string fileName ) : base( fileName ) {
        }
    }
}
