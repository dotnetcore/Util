namespace Util.Localization.Store;

/// <summary>
/// 数据存储本地化资源查找器工厂
/// </summary>
public class StoreStringLocalizerFactory : IStringLocalizerFactory {
    /// <summary>
    /// 日志工厂
    /// </summary>
    private readonly ILoggerFactory _loggerFactory;
    /// <summary>
    /// 本地化资源存储器
    /// </summary>
    private readonly ILocalizedStore _store;
    /// <summary>
    /// 缓存
    /// </summary>
    private readonly IMemoryCache _cache;
    /// <summary>
    /// 本地化配置
    /// </summary>
    private readonly IOptions<LocalizationOptions> _options;

    /// <summary>
    /// 初始化数据存储本地化资源查找器工厂
    /// </summary>
    /// <param name="options">本地化配置</param>
    /// <param name="loggerFactory">日志工厂</param>
    /// <param name="store">本地化资源存储器</param>
    /// <param name="cache">缓存</param>
    public StoreStringLocalizerFactory( IOptions<LocalizationOptions> options, ILoggerFactory loggerFactory, ILocalizedStore store, IMemoryCache cache ) {
        _options = options;
        _loggerFactory = loggerFactory ?? throw new ArgumentNullException( nameof( loggerFactory ) );
        _store = store ?? throw new ArgumentNullException( nameof( store ) );
        _cache = cache ?? throw new ArgumentNullException( nameof( cache ) );
    }

    /// <inheritdoc />
    public IStringLocalizer Create( Type resourceSource ) {
        resourceSource.CheckNull( nameof( resourceSource ) );
        var type = LocalizedTypeAttribute.GetResourceType( resourceSource );
        return new StoreStringLocalizer( _loggerFactory.CreateLogger<StoreStringLocalizer>(), _cache, _store, type, _options );
    }

    /// <inheritdoc />
    public IStringLocalizer Create( string baseName, string location ) {
        return new StoreStringLocalizer( _loggerFactory.CreateLogger<StoreStringLocalizer>(), _cache, _store, baseName, _options );
    }
}