using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Util.Aop {
    /// <summary>
    /// Aop扩展
    /// </summary>
    public static class HostBuilderExtensions {
        /// <summary>
        /// 启用拦截器
        /// </summary>
        /// <param name="builder">主机生成器</param>
        public static IHostBuilder EnableAop( this IHostBuilder builder ) {
            builder.UseServiceProviderFactory( new DynamicProxyServiceProviderFactory() );
            builder.ConfigureServices( ( context, services ) => services.AddAop() );
            return builder;
        }
    }
}
