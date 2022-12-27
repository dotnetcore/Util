using Util.Infrastructure;

namespace Util.Templates.Infrastructure {
    /// <summary>
    /// Razor模板引擎服务注册器配置扩展
    /// </summary>
    public static class ServiceRegistrarConfigExtensions {
        /// <summary>
        /// 启用Razor模板引擎服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig EnableRazorServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Enable( RazorServiceRegistrar.GetId() );
            return config;
        }

        /// <summary>
        ///禁用Razor模板引擎服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableRazorServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Disable( RazorServiceRegistrar.GetId() );
            return config;
        }
    }
}
