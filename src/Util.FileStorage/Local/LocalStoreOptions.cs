namespace Util.FileStorage.Local;

/// <summary>
/// 本地文件存储配置
/// </summary>
public class LocalStoreOptions {
    /// <summary>
    /// 文件存储目录根路径,默认值:"upload"
    /// </summary>
    public string RootPath { get; set; } = "upload";
    /// <summary>
    /// 根路径默认为相对路径,如果要设置为绝对路径,设置为 true
    /// </summary>
    public bool IsAbsolutePath { get; set; }
}