using Util.Configs;
using Util.Ui.Razor;

namespace Util.Ui.NgZorro;

/// <summary>
/// NgZorro配置扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置NgZorro依赖服务
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddNgZorro( this IAppBuilder builder ) {
        return builder.AddNgZorro( null );
    }

    /// <summary>
    /// 配置NgZorro依赖服务
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">NgZorro配置操作</param>
    public static IAppBuilder AddNgZorro( this IAppBuilder builder, Action<NgZorroOptions> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            var options = new NgZorroOptions();
            setupAction?.Invoke( options );
            services.AddRazorPages().AddRazorRuntimeCompilation().AddConventions();
            ConfigSpaStaticFiles( services, options );
            ConfigRazorOptions( services, options );
            ConfigNgZorroOptions( services, setupAction );
        } );
        return builder;
    }

    /// <summary>
    /// 配置Spa静态文件
    /// </summary>
    private static void ConfigSpaStaticFiles( IServiceCollection services, NgZorroOptions options ) {
        services.AddSpaStaticFiles( configuration => {
            configuration.RootPath = options.RootPath;
        } );
    }

    /// <summary>
    /// 配置Razor
    /// </summary>
    private static void ConfigRazorOptions( IServiceCollection services, NgZorroOptions options ) {
        void Action( RazorOptions t ) {
            t.IsGenerateHtml = options.IsGenerateHtml;
            t.GenerateHtmlBasePath = options.GenerateHtmlBasePath;
            t.GenerateHtmlSuffix = options.GenerateHtmlSuffix;
        }
        services.Configure( (Action<RazorOptions>)Action );
    }

    /// <summary>
    /// 配置NgZorro
    /// </summary>
    private static void ConfigNgZorroOptions( IServiceCollection services, Action<NgZorroOptions> setupAction ) {
        if ( setupAction != null )
            services.Configure( setupAction );
    }
}