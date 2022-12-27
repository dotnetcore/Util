using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Applications.Locks;
using Util.Configs;

namespace Util.Applications {
    /// <summary>
    /// 业务锁操作配置扩展
    /// </summary>
    public class LockOptionsExtension : OptionsExtensionBase {
        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.TryAddTransient<ILock, DefaultLock>();
        }
    }
}
