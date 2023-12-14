namespace Util.FileStorage.Aliyun;

/// <summary>
/// 阿里云对象存储操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置阿里云对象存储操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddAliyunOss( this IAppBuilder builder ) {
        return builder.AddAliyunOss( null );
    }

    /// <summary>
    /// 配置阿里云对象存储操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">阿里云对象存储配置操作</param>
    public static IAppBuilder AddAliyunOss( this IAppBuilder builder, Action<AliyunOssOptions> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            if ( setupAction != null )
                services.Configure( setupAction );
            services.TryAddTransient<IFileStore, AliyunFileStore>();
            services.TryAddTransient<IAliyunOssFileStore, AliyunFileStore>();
        } );
        return builder;
    }
}