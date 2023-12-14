namespace Util.FileStorage.Aliyun;

/// <summary>
/// 阿里云对象存储配置提供器
/// </summary>
public class AliyunOssConfigProvider : IAliyunOssConfigProvider {
    /// <summary>
    /// 阿里云对象存储配置
    /// </summary>
    private readonly AliyunOssOptions _options;

    /// <summary>
    /// 初始化阿里云对象存储配置提供器
    /// </summary>
    /// <param name="options">阿里云对象存储配置</param>
    public AliyunOssConfigProvider( IOptions<AliyunOssOptions> options ) : this( options.Value ) {
    }

    /// <summary>
    /// 初始化阿里云对象存储配置提供器
    /// </summary>
    /// <param name="options">阿里云对象存储配置</param>
    public AliyunOssConfigProvider( AliyunOssOptions options ) {
        options.CheckNull( nameof( options ) );
        _options = options;
    }

    /// <summary>
    /// 获取配置
    /// </summary>
    public Task<AliyunOssOptions> GetConfigAsync() {
        return Task.FromResult( _options );
    }
}