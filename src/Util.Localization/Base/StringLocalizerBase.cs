using Util.Localization.Caching;

namespace Util.Localization.Base;

/// <summary>
/// 本地化资源查找器
/// </summary>
public abstract class StringLocalizerBase : IStringLocalizer {
    /// <summary>
    /// 缓存
    /// </summary>
    private readonly IMemoryCache _cache;
    /// <summary>
    /// 资源类型
    /// </summary>
    private readonly string _type;

    /// <summary>
    /// 初始化本地化资源查找器
    /// </summary>
    /// <param name="cache">缓存</param>
    /// <param name="type">资源类型</param>
    protected StringLocalizerBase( IMemoryCache cache, string type ) {
        _cache = cache;
        _type = type;
    }

    /// <inheritdoc />
    public LocalizedString this[string name] {
        get {
            if ( name.IsEmpty() )
                throw new ArgumentNullException( nameof( name ) );
            return GetResult( name );
        }
    }

    /// <inheritdoc />
    public LocalizedString this[string name, params object[] arguments] {
        get {
            if ( name.IsEmpty() )
                throw new ArgumentNullException( nameof( name ) );
            return GetResult( name, arguments );
        }
    }

    /// <summary>
    /// 获取本地化字符串结果
    /// </summary>
    /// <param name="name">资源名称</param>
    /// <param name="arguments">参数列表</param>
    protected virtual LocalizedString GetResult( string name, params object[] arguments ) {
        LocalizedString result = null;
        var cultures = Util.Helpers.Culture.GetCurrentUICultures();
        foreach ( var culture in cultures ) {
            result = GetLocalizedStringByCache( culture, name );
            if ( result.ResourceNotFound == false )
                return FormatResult( result, name, arguments );
        }
        return FormatResult( result, name, arguments );
    }

    /// <summary>
    /// 从缓存获取本地化字符串
    /// </summary>
    /// <param name="culture">区域文化</param>
    /// <param name="name">资源名称</param>
    protected virtual LocalizedString GetLocalizedStringByCache( CultureInfo culture, string name ) {
        var key = CacheKeyHelper.GetCacheKey( culture.Name, _type, name );
        return _cache == null ? GetLocalizedString( culture, name ) : _cache.GetOrCreate( key, _ => GetLocalizedString( culture, name ) );
    }

    /// <summary>
    /// 获取本地化字符串
    /// </summary>
    /// <param name="culture">区域文化</param>
    /// <param name="name">资源名称</param>
    protected virtual LocalizedString GetLocalizedString( CultureInfo culture, string name ) {
        var value = GetValue( culture, name,_type );
        if ( value.IsEmpty() )
            return new LocalizedString( name, string.Empty, true, null );
        return new LocalizedString( name, value, false, null );
    }

    /// <summary>
    /// 获取资源值
    /// </summary>
    /// <param name="culture">区域文化</param>
    /// <param name="name">资源名称</param>
    /// <param name="type">资源类型</param>
    protected abstract string GetValue( CultureInfo culture, string name, string type );

    /// <summary>
    /// 格式化结果
    /// </summary>
    /// <param name="result">本地化字符串结果</param>
    /// <param name="name">资源名称</param>
    /// <param name="arguments">参数列表</param>
    protected virtual LocalizedString FormatResult( LocalizedString result, string name, params object[] arguments ) {
        if( result == null )
            return new LocalizedString( name, string.Format( name, arguments ), true, null );
        if ( result.ResourceNotFound )
            return new LocalizedString( result.Name, string.Format( result.Name, arguments ), true, null );
        if ( arguments == null || arguments.Length == 0 )
            return result;
        return new LocalizedString( result.Name, string.Format( result.Value, arguments ), false, result.SearchedLocation );
    }

    /// <summary>
    /// 获取全部本地化字符串
    /// </summary>
    /// <param name="includeParentCultures">是否包含父区域</param>
    public abstract IEnumerable<LocalizedString> GetAllStrings( bool includeParentCultures );
}