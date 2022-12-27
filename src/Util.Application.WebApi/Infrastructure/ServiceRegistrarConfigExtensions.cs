using Util.Infrastructure;

namespace Util.Applications.Infrastructure {
    /// <summary>
    /// Web Api服务注册器配置扩展
    /// </summary>
    public static class ServiceRegistrarConfigExtensions {
        /// <summary>
        /// 启用Web Api服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig EnableWebApiServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Enable( WebApiServiceRegistrar.GetId() );
            return config;
        }

        /// <summary>
        ///禁用Web Api服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableWebApiServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Disable( WebApiServiceRegistrar.GetId() );
            return config;
        }
    }
}
