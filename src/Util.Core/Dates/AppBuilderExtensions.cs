using Util.Configs;

namespace Util.Dates;

/// <summary>
/// 日期操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置使用Utc日期
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddUtc( this IAppBuilder builder ) {
        return builder.AddUtc( true );
    }

    /// <summary>
    /// 配置使用Utc日期
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="isUseUtc">是否使用Utc日期</param>
    public static IAppBuilder AddUtc( this IAppBuilder builder, bool isUseUtc ) {
        builder.CheckNull( nameof( builder ) );
        TimeOptions.IsUseUtc = isUseUtc;
        return builder;
    }
}