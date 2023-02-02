using Util.Infrastructure;

namespace Util.Templates.Infrastructure {
    /// <summary>
    /// Handlebars模板引擎服务注册器配置扩展
    /// </summary>
    public static class ServiceRegistrarConfigExtensions {
        /// <summary>
        /// 启用Handlebars模板引擎服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig EnableHandlebarsServiceRegistrar( this ServiceRegistrarConfig config ) {
            ServiceRegistrarConfig.Enable( HandlebarsServiceRegistrar.ServiceName );
            return config;
        }

        /// <summary>
        ///禁用Handlebars模板引擎服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableHandlebarsServiceRegistrar( this ServiceRegistrarConfig config ) {
            ServiceRegistrarConfig.Disable( HandlebarsServiceRegistrar.ServiceName );
            return config;
        }
    }
}
