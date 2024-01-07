namespace Util.FileStorage; 

/// <summary>
/// 文件信息
/// </summary>
public class FileStorageInfo {
    /// <summary>
    /// 文件标识
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// 文件路径
    /// </summary>
    public string FilePath { get; set; }
    /// <summary>
    /// 文件名,包含扩展名
    /// </summary>
    public string FileName { get; set; }
    /// <summary>
    /// 文件名,不包含扩展名
    /// </summary>
    public string FileNameWithoutExtension { get; set; }
    /// <summary>
    /// 扩展名
    /// </summary>
    public string Extension { get; set; }
    /// <summary>
    /// 文件大小
    /// </summary>
    public long Size { get; set; }
    /// <summary>
    /// 文件大小描述
    /// </summary>
    public string SizeDescription { get; set; }
    /// <summary>
    /// 文件访问地址
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 缩略图访问地址
    /// </summary>
    public string ThumbUrl { get; set; }
}