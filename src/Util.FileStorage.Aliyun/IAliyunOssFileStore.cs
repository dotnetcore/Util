namespace Util.FileStorage.Aliyun;

/// <summary>
/// 阿里云对象存储服务
/// </summary>
public interface IAliyunOssFileStore : IFileStore {
    /// <summary>
    /// 创建存储桶
    /// </summary>
    /// <param name="args">创建存储桶参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task CreateBucketAsync( CreateBucketArgs args, CancellationToken cancellationToken = default );
}