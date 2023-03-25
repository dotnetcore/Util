using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Configs;
using Util.Security.Authorization;

namespace Util {
    /// <summary>
    /// AspNetCore操作配置扩展
    /// </summary>
    public class AspNetCoreOptionsExtension<TPermissionManager, TAuthorizationMiddlewareResultHandler> : OptionsExtensionBase 
        where TPermissionManager : class,IPermissionManager
        where TAuthorizationMiddlewareResultHandler : class, IAuthorizationMiddlewareResultHandler {
        /// <summary>
        /// 初始化AspNetCore操作配置扩展
        /// </summary>
        public AspNetCoreOptionsExtension() {
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.AddSingleton<IAuthorizationHandler, AclHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, AclPolicyProvider>();
            services.AddSingleton<IAuthorizationMiddlewareResultHandler, TAuthorizationMiddlewareResultHandler>();
            services.AddSingleton<IPermissionManager, TPermissionManager>();
        }
    }
}
