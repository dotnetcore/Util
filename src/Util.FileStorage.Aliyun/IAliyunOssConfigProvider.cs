namespace Util.FileStorage.Aliyun;

/// <summary>
/// 阿里云对象存储配置提供器
/// </summary>
public interface IAliyunOssConfigProvider : ITransientDependency {
    /// <summary>
    /// 获取配置
    /// </summary>
    Task<AliyunOssOptions> GetConfigAsync();
}