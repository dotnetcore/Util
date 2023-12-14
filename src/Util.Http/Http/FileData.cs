namespace Util.Http;

/// <summary>
/// 文件数据
/// </summary>
public class FileData {
    /// <summary>
    /// 初始化文件数据
    /// </summary>
    /// <param name="stream">文件流</param>
    /// <param name="fileName">文件名</param>
    /// <param name="name">参数名</param>
    public FileData( Stream stream,string fileName,string name ) {
        Stream = stream;
        FileName = fileName;
        Name = name;
    }

    /// <summary>
    /// 初始化文件数据
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="name">参数名</param>
    public FileData( string filePath, string name ) {
        FilePath = filePath;
        Name = name;
    }

    /// <summary>
    /// 文件流
    /// </summary>
    public Stream Stream { get; }
    /// <summary>
    /// 文件路径
    /// </summary>
    public string FilePath { get; }
    /// <summary>
    /// 文件名
    /// </summary>
    public string FileName { get; }
    /// <summary>
    /// 参数名
    /// </summary>
    public string Name { get; }
}