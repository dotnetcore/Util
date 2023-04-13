namespace Util.FileStorage {
    /// <summary>
    /// 文件是否存在方法参数
    /// </summary>
    public class FileExistsArgs : FileStorageArgs {
        /// <summary>
        /// 初始化文件是否存在方法参数
        /// </summary>
        /// <param name="fileName">文件名</param>
        public FileExistsArgs( string fileName ) : base( fileName ) {
        }
    }
}
