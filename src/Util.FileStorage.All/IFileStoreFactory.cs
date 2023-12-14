namespace Util.FileStorage;

/// <summary>
/// 文件存储服务工厂
/// </summary>
public interface IFileStoreFactory : ITransientDependency {
    /// <summary>
    /// 创建文件存储服务
    /// </summary>
    /// <param name="options">本地文件存储配置</param>
    IFileStore Create( LocalStoreOptions options );
    /// <summary>
    /// 创建文件存储服务
    /// </summary>
    /// <param name="options">Minio配置</param>
    IFileStore Create( MinioOptions options );
    /// <summary>
    /// 创建文件存储服务
    /// </summary>
    /// <param name="options">阿里云对象存储配置</param>
    IFileStore Create( AliyunOssOptions options );
    /// <summary>
    /// 创建阿里云对象存储服务
    /// </summary>
    /// <param name="options">阿里云对象存储配置</param>
    IAliyunOssFileStore CreateAliyunOss( AliyunOssOptions options );
}