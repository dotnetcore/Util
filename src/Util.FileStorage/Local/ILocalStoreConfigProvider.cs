namespace Util.FileStorage.Local;

/// <summary>
/// 本地文件存储配置提供器
/// </summary>
public interface ILocalStoreConfigProvider : ITransientDependency {
    /// <summary>
    /// 获取配置
    /// </summary>
    Task<LocalStoreOptions> GetConfigAsync();
}