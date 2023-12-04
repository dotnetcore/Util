namespace Util.FileStorage.Minio;

/// <summary>
/// Minio配置提供器
/// </summary>
public class MinioConfigProvider : IMinioConfigProvider {
    /// <summary>
    /// Minio配置
    /// </summary>
    private readonly MinioOptions _options;

    /// <summary>
    /// 初始化Minio配置提供器
    /// </summary>
    /// <param name="options">Minio配置</param>
    public MinioConfigProvider( IOptions<MinioOptions> options ) : this( options.Value ) {
    }

    /// <summary>
    /// 初始化Minio配置提供器
    /// </summary>
    /// <param name="options">Minio配置</param>
    public MinioConfigProvider( MinioOptions options ) {
        options.CheckNull( nameof( options ) );
        _options = options;
    }

    /// <summary>
    /// 获取配置
    /// </summary>
    public Task<MinioOptions> GetConfigAsync() {
        return Task.FromResult( _options );
    }
}