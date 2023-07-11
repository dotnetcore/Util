using Util.Configs;
using Util.Helpers;

namespace Util.Aop;

/// <summary>
/// Aop配置扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 启用AspectCore拦截器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddAop( this IAppBuilder builder ) {
        return builder.AddAop( null );
    }

    /// <summary>
    /// 启用AspectCore拦截器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">AspectCore拦截器配置操作</param>
    public static IAppBuilder AddAop( this IAppBuilder builder, Action<IAspectConfiguration> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.UseServiceProviderFactory( new DynamicProxyServiceProviderFactory() );
        builder.Host.ConfigureServices( ( context, services ) => {
            ConfigureDynamicProxy( services, setupAction );
            RegisterAspectScoped( services );
        } );
        return builder;
    }

    /// <summary>
    /// 配置拦截器
    /// </summary>
    private static void ConfigureDynamicProxy( IServiceCollection services, Action<IAspectConfiguration> setupAction ) {
        services.ConfigureDynamicProxy( config => {
            config.EnableParameterAspect();
            config.NonAspectPredicates.Add( t => Reflection.GetTopBaseType( t.DeclaringType ).SafeString() == "Microsoft.EntityFrameworkCore.DbContext" );
            config.NonAspectPredicates.Add( t => t.DeclaringType.SafeString().Contains( "Xunit.DependencyInjection.ITestOutputHelperAccessor" ) );
            setupAction?.Invoke( config );
        } );
    }

    /// <summary>
    /// 注册拦截作用域
    /// </summary>
    private static void RegisterAspectScoped( IServiceCollection services ) {
        services.AddScoped<IAspectScheduler, ScopeAspectScheduler>();
        services.AddScoped<IAspectBuilderFactory, ScopeAspectBuilderFactory>();
        services.AddScoped<IAspectContextFactory, ScopeAspectContextFactory>();
    }
}