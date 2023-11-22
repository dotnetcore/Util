using Util.Helpers;

namespace Util.Configs;

/// <summary>
/// 应用生成器
/// </summary>
public class AppBuilder : IAppBuilder {
    /// <summary>
    /// 初始化应用生成器
    /// </summary>
    /// <param name="host">主机生成器</param>
    public AppBuilder( IHostBuilder host ) {
        Host = host ?? throw new ArgumentNullException( nameof( host ) );
    }

    /// <inheritdoc />
    public IHostBuilder Host { get; }

    /// <summary>
    /// 构建
    /// </summary>
    public IHost Build() {
        var result = Host.Build();
        Ioc.SetServiceProviderAction( () => result.Services );
        return result;
    }
}