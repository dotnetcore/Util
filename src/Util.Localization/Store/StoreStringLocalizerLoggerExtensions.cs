namespace Util.Localization.Store; 

/// <summary>
/// 数据存储本地化日志扩展
/// </summary>
internal static class StoreStringLocalizerLoggerExtensions {
    private static readonly Action<ILogger, string, string, CultureInfo, Exception> _searched;

    static StoreStringLocalizerLoggerExtensions() {
        _searched = LoggerMessage.Define<string, string, CultureInfo>(
            LogLevel.Debug,
            1,
            $"{nameof( StoreStringLocalizer )} 查找名为 '{{Key}}'的本地化资源, 资源类型为 '{{Type}}',区域文化为 '{{Culture}}'." );
    }

    public static void Searched( this ILogger logger, string key, string type, CultureInfo culture ) {
        _searched( logger, key, type, culture, null );
    }
}