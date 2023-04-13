using System;

namespace Util.FileStorage {
    /// <summary>
    /// 文件处理结果
    /// </summary>
    public class FileResult {
        /// <summary>
        /// 初始化文件处理结果
        /// </summary>
        /// <param name="filePath">文件标识</param>
        /// <param name="size">文件大小</param>
        /// <param name="bucket">存储桶名称</param>
        public FileResult( string filePath, long? size,string bucket = null ) {
            if ( filePath.IsEmpty() )
                throw new ArgumentNullException( nameof(filePath) );
            FilePath = filePath;
            FileName = System.IO.Path.GetFileName( filePath );
            Extension = System.IO.Path.GetExtension( FileName )?.TrimStart( '.' );
            Size = new FileSize( size.SafeValue() );
            Bucket = bucket;
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; }
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
        /// <summary>
        /// 存储桶名称
        /// </summary>
        public string Bucket { get; }
    }
}
