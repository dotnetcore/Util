using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Util.FileStorage {
    /// <summary>
    /// 文件存储服务
    /// </summary>
    public interface IFileStore {
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
        /// <param name="fileName">文件名</param>
        /// <param name="policy">文件名处理策略</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<bool> FileExistsAsync( string fileName, string policy = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="args">参数</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<bool> FileExistsAsync( FileExistsArgs args, CancellationToken cancellationToken = default );
        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="policy">文件名处理策略</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<Stream> GetFileStreamAsync( string fileName, string policy = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <param name="args">参数</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<Stream> GetFileStreamAsync( GetFileStreamArgs args, CancellationToken cancellationToken = default );
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <param name="fileName">文件名,包含扩展名</param>
        /// <param name="policy">文件名处理策略</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<FileResult> SaveFileAsync( Stream stream, string fileName, string policy = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="args">参数</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<FileResult> SaveFileAsync( SaveFileArgs args, CancellationToken cancellationToken = default );
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="policy">文件名处理策略</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task DeleteFileAsync( string fileName, string policy = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="args">参数</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task DeleteFileAsync( DeleteFileArgs args, CancellationToken cancellationToken = default );
        /// <summary>
        /// 生成下载Url,供客户端直接下载
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="policy">文件名处理策略</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<string> GenerateDownloadUrlAsync( string fileName, string policy = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 生成下载Url,供客户端直接下载
        /// </summary>
        /// <param name="args">参数</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<string> GenerateDownloadUrlAsync( GenerateDownloadUrlArgs args, CancellationToken cancellationToken = default );
        /// <summary>
        /// 生成上传Url,供客户端直接上传
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="policy">文件名处理策略</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<string> GenerateUploadUrlAsync( string fileName, string policy = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 生成上传Url,供客户端直接上传
        /// </summary>
        /// <param name="args">参数</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<string> GenerateUploadUrlAsync( GenerateUploadUrlArgs args, CancellationToken cancellationToken = default );
        /// <summary>
        /// 清空存储桶和文件
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        Task ClearAsync( CancellationToken cancellationToken = default );
    }
}
