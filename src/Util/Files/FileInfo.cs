namespace Util.Files {
    /// <summary>
    /// 文件信息
    /// </summary>
    public class FileInfo {
        /// <summary>
        /// 初始化文件信息
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="size">文件大小</param>
        /// <param name="fileName">文件名</param>
        /// <param name="id">文件标识</param>
        public FileInfo( string path, long? size, string fileName = null, string id = null ) {
            Path = path;
            Size = new FileSize( size.SafeValue() );
            Extension = System.IO.Path.GetExtension( path )?.TrimStart( '.' );
            FileName = string.IsNullOrWhiteSpace( fileName ) ? System.IO.Path.GetFileName( path ) : fileName;
            Id = id;
        }

        /// <summary>
        /// 文件标识
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path { get; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Extension { get; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public FileSize Size { get; }
    }
}
