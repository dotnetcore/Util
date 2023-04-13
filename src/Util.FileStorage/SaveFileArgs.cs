using System.IO;

namespace Util.FileStorage {
    /// <summary>
    /// 保存文件方法参数
    /// </summary>
    public class SaveFileArgs : FileStorageArgs {
        /// <summary>
        /// 初始化保存文件方法参数
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="stream">文件流</param>
        public SaveFileArgs( string fileName, Stream stream ) : base( fileName ) {
            Stream = stream;
        }

        /// <summary>
        /// 文件流
        /// </summary>
        public Stream Stream { get; }
    }
}
