namespace Util.FileStorage.Local;

/// <summary>
/// 本地文件存储配置提供器
/// </summary>
public class LocalStoreConfigProvider : ILocalStoreConfigProvider {
    /// <summary>
    /// 本地文件存储配置
    /// </summary>
    private readonly LocalStoreOptions _options;

    /// <summary>
    /// 初始化本地文件存储配置提供器
    /// </summary>
    /// <param name="options">本地文件存储配置</param>
    public LocalStoreConfigProvider( IOptions<LocalStoreOptions> options ) : this( options.Value ) {
    }

    /// <summary>
    /// 初始化本地文件存储配置提供器
    /// </summary>
    /// <param name="options">本地文件存储配置</param>
    public LocalStoreConfigProvider( LocalStoreOptions options ) {
        options.CheckNull( nameof( options ) );
        _options = options;
    }

    /// <summary>
    /// 获取配置
    /// </summary>
    public Task<LocalStoreOptions> GetConfigAsync() {
        return Task.FromResult( _options );
    }
}