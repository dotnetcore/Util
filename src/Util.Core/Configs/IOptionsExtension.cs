using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Util.Configs {
    /// <summary>
    /// 配置项扩展
    /// </summary>
    public interface IOptionsExtension {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="context">主机生成器上下文</param>
        /// <param name="services">服务集合</param>
        void ConfigureServices( HostBuilderContext context, IServiceCollection services );
        /// <summary>
        /// 配置应用
        /// </summary>
        /// <param name="context">主机生成器上下文</param>
        /// <param name="configurationBuilder">配置生成器</param>
        void ConfigureAppConfiguration( HostBuilderContext context, IConfigurationBuilder configurationBuilder );
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="hostBuilder">主机生成器</param>
        void Config( IHostBuilder hostBuilder );
    }
}
