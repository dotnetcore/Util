namespace Util.FileStorage;

/// <summary>
/// 客户端直传参数
/// </summary>
public class DirectUploadParam {
    /// <summary>
    /// 初始化客户端直传参数
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="url">直传Url</param>
    /// <param name="data">直传数据</param>
    /// <param name="originalFileName">原始文件名</param>
    /// <param name="bucket">存储桶名称</param>
    public DirectUploadParam( string filePath, string url, object data = null, string originalFileName = null, string bucket = null ) {
        if( filePath.IsEmpty() )
            throw new ArgumentNullException( nameof( filePath ) );
        FilePath = filePath;
        Url = url;
        Data = data;
        FileName = System.IO.Path.GetFileName( filePath );
        Extension = System.IO.Path.GetExtension( FileName )?.TrimStart( '.' );
        OriginalFileName = originalFileName;
        Bucket = bucket;
    }

    /// <summary>
    /// 直传Url
    /// </summary>
    public string Url { get; }
    /// <summary>
    /// 直传数据
    /// </summary>
    public object Data { get; }
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
    /// 存储桶名称
    /// </summary>
    public string Bucket { get; }
}