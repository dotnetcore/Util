namespace Util.FileStorage {
    /// <summary>
    /// 删除文件方法参数
    /// </summary>
    public class DeleteFileArgs : FileStorageArgs {
        /// <summary>
        /// 初始化删除文件方法参数
        /// </summary>
        /// <param name="fileName">文件名</param>
        public DeleteFileArgs( string fileName ) : base( fileName ) {
        }
    }
}
