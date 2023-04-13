namespace Util.FileStorage {
    /// <summary>
    /// 获取文件流方法参数
    /// </summary>
    public class GetFileStreamArgs : FileStorageArgs {
        /// <summary>
        /// 初始化获取文件流方法参数
        /// </summary>
        /// <param name="fileName">文件名</param>
        public GetFileStreamArgs( string fileName ) : base( fileName ) {
        }
    }
}
