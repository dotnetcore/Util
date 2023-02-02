using Util.Infrastructure;

namespace Util.Data.Infrastructure {
    /// <summary>
    /// Dapper服务注册器配置扩展
    /// </summary>
    public static class ServiceRegistrarConfigExtensions {
        /// <summary>
        /// 启用Dapper服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig EnableDapperServiceRegistrar( this ServiceRegistrarConfig config ) {
            ServiceRegistrarConfig.Enable( DapperServiceRegistrar.ServiceName );
            return config;
        }

        /// <summary>
        ///禁用Dapper服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableDapperServiceRegistrar( this ServiceRegistrarConfig config ) {
            ServiceRegistrarConfig.Disable( DapperServiceRegistrar.ServiceName );
            return config;
        }
    }
}
