namespace Util.FileStorage; 

/// <summary>
/// 文件存储服务
/// </summary>
public interface IFileStore : ILocalFileStore {
    /// <summary>
    /// 获取存储桶名称列表
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task<List<string>> GetBucketNamesAsync( CancellationToken cancellationToken = default );
    /// <summary>
    /// 存储桶是否存在
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="policy">存储桶名称处理策略</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<bool> BucketExistsAsync( string bucketName,string policy = null, CancellationToken cancellationToken = default );
    /// <summary>
    /// 创建存储桶
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="policy">存储桶名称处理策略</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task CreateBucketAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default );
    /// <summary>
    /// 删除存储桶
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="policy">存储桶名称处理策略</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task DeleteBucketAsync( string bucketName, string policy = null, CancellationToken cancellationToken = default );
    /// <summary>
    /// 文件是否存在
    /// </summary>
    /// <param name="args">参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<bool> FileExistsAsync( FileExistsArgs args, CancellationToken cancellationToken = default );
    /// <summary>
    /// 获取文件流
    /// </summary>
    /// <param name="args">参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<Stream> GetFileStreamAsync( GetFileStreamArgs args, CancellationToken cancellationToken = default );
    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="args">参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<FileResult> SaveFileAsync( SaveFileArgs args, CancellationToken cancellationToken = default );
    /// <summary>
    /// 下载远程文件并保存到文件存储
    /// </summary>
    /// <param name="args">参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<FileResult> SaveFileByUrlAsync( SaveFileByUrlArgs args, CancellationToken cancellationToken = default );
    /// <summary>
    /// 复制文件
    /// </summary>
    /// <param name="sourceArgs">源文件参数</param>
    /// <param name="destinationArgs">目标文件参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task CopyFileAsync( FileStorageArgs sourceArgs, FileStorageArgs destinationArgs, CancellationToken cancellationToken = default );
    /// <summary>
    /// 移动文件
    /// </summary>
    /// <param name="sourceArgs">源文件参数</param>
    /// <param name="destinationArgs">目标文件参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task MoveFileAsync( FileStorageArgs sourceArgs, FileStorageArgs destinationArgs, CancellationToken cancellationToken = default );
    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="args">参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task DeleteFileAsync( DeleteFileArgs args, CancellationToken cancellationToken = default );
    /// <summary>
    /// 生成客户端下载Url
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<string> GenerateDownloadUrlAsync( string fileName, CancellationToken cancellationToken = default );
    /// <summary>
    /// 生成客户端下载Url
    /// </summary>
    /// <param name="args">参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<string> GenerateDownloadUrlAsync( GenerateDownloadUrlArgs args, CancellationToken cancellationToken = default );
    /// <summary>
    /// 生成客户端临时下载Url
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<string> GenerateTempDownloadUrlAsync( string fileName, CancellationToken cancellationToken = default );
    /// <summary>
    /// 生成客户端临时下载Url
    /// </summary>
    /// <param name="args">参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<string> GenerateTempDownloadUrlAsync( GenerateTempDownloadUrlArgs args, CancellationToken cancellationToken = default );
    /// <summary>
    /// 生成客户端直传Url
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <param name="policy">文件名处理策略</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<DirectUploadParam> GenerateUploadUrlAsync( string fileName, string policy = null, CancellationToken cancellationToken = default );
    /// <summary>
    /// 生成客户端直传Url
    /// </summary>
    /// <param name="args">参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<DirectUploadParam> GenerateUploadUrlAsync( GenerateUploadUrlArgs args, CancellationToken cancellationToken = default );
    /// <summary>
    /// 清空存储桶和文件
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task ClearAsync( CancellationToken cancellationToken = default );
}