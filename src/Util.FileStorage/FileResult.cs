namespace Util.FileStorage;

/// <summary>
/// 文件处理结果
/// </summary>
public class FileResult {
    /// <summary>
    /// 初始化文件处理结果
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="size">文件大小</param>
    /// <param name="originalFileName">原始文件名</param>
    /// <param name="bucket">存储桶名称</param>
    public FileResult( string filePath, long? size, string originalFileName = null, string bucket = null ) {
        if( filePath.IsEmpty() )
            throw new ArgumentNullException( nameof( filePath ) );
        FilePath = filePath;
        Size = new FileSize( size.SafeValue() );
        FileName = System.IO.Path.GetFileName( filePath );
        Extension = System.IO.Path.GetExtension( FileName )?.TrimStart( '.' );
        OriginalFileName = originalFileName;
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
    /// 原始文件名
    /// </summary>
    public string OriginalFileName { get; }
    /// <summary>
    /// 文件大小
    /// </summary>
    public FileSize Size { get; }
    /// <summary>
    /// 存储桶名称
    /// </summary>
    public string Bucket { get; }
}