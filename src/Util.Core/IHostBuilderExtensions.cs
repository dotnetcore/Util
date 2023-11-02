using Util.Configs;
using Util.Infrastructure;

namespace Util; 

/// <summary>
/// 主机生成器服务扩展
/// </summary>
public static class IHostBuilderExtensions {
    /// <summary>
    /// 启动Util服务 
    /// </summary>
    /// <param name="hostBuilder">主机生成器</param>
    public static IHostBuilder AddUtil( this IHostBuilder hostBuilder ) {
        hostBuilder.CheckNull( nameof( hostBuilder ) );
        var bootstrapper = new Bootstrapper( hostBuilder );
        bootstrapper.Start();
        return hostBuilder;
    }

    /// <summary>
    /// 转换为Util应用生成器
    /// </summary>
    /// <param name="hostBuilder">主机生成器</param>
    public static IAppBuilder AsBuild( this IHostBuilder hostBuilder ) {
        hostBuilder.CheckNull( nameof( hostBuilder ) );
        return new AppBuilder( hostBuilder );
    }

    /// <summary>
    /// 启动Util服务 
    /// </summary>
    /// <param name="appBuilder">应用生成器</param>
    public static IAppBuilder AddUtil( this IAppBuilder appBuilder ) {
        appBuilder.CheckNull( nameof( appBuilder ) );
        var bootstrapper = new Bootstrapper( appBuilder.Host );
        bootstrapper.Start();
        return appBuilder;
    }
}