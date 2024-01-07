namespace Util.FileStorage; 

/// <summary>
/// 本地文件存储服务
/// </summary>
public interface ILocalFileStore {
    /// <summary>
    /// 文件是否存在
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <param name="policy">文件名处理策略</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<bool> FileExistsAsync( string fileName, string policy = null, CancellationToken cancellationToken = default );
    /// <summary>
    /// 获取文件流
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<Stream> GetFileStreamAsync( string fileName, CancellationToken cancellationToken = default );
    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="stream">文件流</param>
    /// <param name="fileName">文件名,包含扩展名</param>
    /// <param name="policy">文件名处理策略</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<FileResult> SaveFileAsync( Stream stream, string fileName, string policy = null, CancellationToken cancellationToken = default );
    /// <summary>
    /// 下载远程文件并保存到文件存储
    /// </summary>
    /// <param name="url">远程下载地址</param>
    /// <param name="fileName">文件名,包含扩展名</param>
    /// <param name="policy">文件名处理策略</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<FileResult> SaveFileByUrlAsync( string url, string fileName, string policy = null, CancellationToken cancellationToken = default );
    /// <summary>
    /// 复制文件
    /// </summary>
    /// <param name="sourceFileName">源文件名</param>
    /// <param name="destinationFileName">目标文件名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task CopyFileAsync( string sourceFileName, string destinationFileName, CancellationToken cancellationToken = default );
    /// <summary>
    /// 移动文件
    /// </summary>
    /// <param name="sourceFileName">源文件名</param>
    /// <param name="destinationFileName">目标文件名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task MoveFileAsync( string sourceFileName, string destinationFileName, CancellationToken cancellationToken = default );
    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task DeleteFileAsync( string fileName, CancellationToken cancellationToken = default );
}