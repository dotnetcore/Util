using Util.Configs;

namespace Util.FileStorage.Minio;

/// <summary>
/// Minio文件存储操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置Minio文件存储操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddMinio( this IAppBuilder builder ) {
        return builder.AddMinio( null );
    }

    /// <summary>
    /// 配置Minio文件存储操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">Minio配置操作</param>
    public static IAppBuilder AddMinio( this IAppBuilder builder, Action<MinioOptions> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            if ( setupAction != null )
                services.Configure( setupAction );
            services.TryAddTransient<IFileStore, MinioFileStore>();
        } );
        return builder;
    }
}