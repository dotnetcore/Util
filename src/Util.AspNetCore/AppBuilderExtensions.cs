namespace Util;

/// <summary>
/// AspNetCore操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置授权访问控制
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddAcl( this IAppBuilder builder ) {
        return builder.AddAcl<DefaultPermissionManager>();
    }

    /// <summary>
    /// 配置授权访问控制
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">访问控制配置操作</param>
    public static IAppBuilder AddAcl( this IAppBuilder builder, Action<AclOptions> setupAction ) {
        return builder.AddAcl<DefaultPermissionManager>( setupAction );
    }

    /// <summary>
    /// 配置授权访问控制
    /// </summary>
    /// <typeparam name="TPermissionManager">权限管理器类型</typeparam>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddAcl<TPermissionManager>( this IAppBuilder builder ) where TPermissionManager : class, IPermissionManager {
        return builder.AddAcl<TPermissionManager, AclMiddlewareResultHandler>();
    }

    /// <summary>
    /// 配置授权访问控制
    /// </summary>
    /// <typeparam name="TPermissionManager">权限管理器类型</typeparam>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">访问控制配置操作</param>
    public static IAppBuilder AddAcl<TPermissionManager>( this IAppBuilder builder, Action<AclOptions> setupAction ) where TPermissionManager : class, IPermissionManager {
        return builder.AddAcl<TPermissionManager, AclMiddlewareResultHandler>( setupAction );
    }

    /// <summary>
    /// 配置授权访问控制
    /// </summary>
    /// <typeparam name="TPermissionManager">权限管理器类型</typeparam>
    /// <typeparam name="TAuthorizationMiddlewareResultHandler">授权中间件结果处理器类型</typeparam>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddAcl<TPermissionManager, TAuthorizationMiddlewareResultHandler>( this IAppBuilder builder )
        where TPermissionManager : class, IPermissionManager
        where TAuthorizationMiddlewareResultHandler : class, IAuthorizationMiddlewareResultHandler {
        return builder.AddAcl<TPermissionManager, TAuthorizationMiddlewareResultHandler>( null );
    }

    /// <summary>
    /// 配置授权访问控制
    /// </summary>
    /// <typeparam name="TPermissionManager">权限管理器类型</typeparam>
    /// <typeparam name="TAuthorizationMiddlewareResultHandler">授权中间件结果处理器类型</typeparam>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">访问控制配置操作</param>
    public static IAppBuilder AddAcl<TPermissionManager, TAuthorizationMiddlewareResultHandler>( this IAppBuilder builder, Action<AclOptions> setupAction )
        where TPermissionManager : class, IPermissionManager
        where TAuthorizationMiddlewareResultHandler : class, IAuthorizationMiddlewareResultHandler {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.AddSingleton<IAuthorizationHandler, AclHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, AclPolicyProvider>();
            services.AddSingleton<IAuthorizationMiddlewareResultHandler, TAuthorizationMiddlewareResultHandler>();
            services.AddSingleton<IPermissionManager, TPermissionManager>();
            if ( setupAction != null )
                services.Configure( setupAction );
        } );
        return builder;
    }
}