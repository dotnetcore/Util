namespace Util.FileStorage; 

/// <summary>
/// 文件名过滤器
/// </summary>
public class FileNameFilter : IFileNameFilter {
    /// <inheritdoc />
    public string Filter( string fileName ) {
        return fileName;
    }
}