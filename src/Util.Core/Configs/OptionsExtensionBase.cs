using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Util.Configs {
    /// <summary>
    /// 配置项扩展
    /// </summary>
    public abstract class OptionsExtensionBase : IOptionsExtension {
        /// <inheritdoc />
        public virtual void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
        }

        /// <inheritdoc />
        public virtual void ConfigureAppConfiguration( HostBuilderContext context, IConfigurationBuilder configurationBuilder ) {
        }

        /// <inheritdoc />
        public virtual void Config( IHostBuilder hostBuilder ) {
        }
    }
}
