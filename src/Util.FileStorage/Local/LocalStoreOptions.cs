namespace Util.FileStorage.Local;

/// <summary>
/// 本地文件存储配置
/// </summary>
public class LocalStoreOptions {
    /// <summary>
    /// 文件存储目录根路径,默认值:"upload"
    /// </summary>
    public string RootPath { get; set; } = "upload";
}