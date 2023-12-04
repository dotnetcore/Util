using Util.Configs;
using Util.FileStorage.Local;

namespace Util.FileStorage;

/// <summary>
/// 本地文件存储操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置本地文件存储操作,将文件上传到Web服务器目录
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddLocalFileStore( this IAppBuilder builder ) {
        return builder.AddLocalFileStore( null );
    }

    /// <summary>
    /// 配置本地文件存储操作,将文件上传到Web服务器目录
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">本地文件存储配置操作</param>
    public static IAppBuilder AddLocalFileStore( this IAppBuilder builder, Action<LocalStoreOptions> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            if( setupAction != null )
                services.Configure( setupAction );
            services.TryAddTransient<IFileStore, LocalFileStore>();
            services.TryAddTransient<ILocalFileStore, LocalFileStore>();
        } );
        return builder;
    }
}