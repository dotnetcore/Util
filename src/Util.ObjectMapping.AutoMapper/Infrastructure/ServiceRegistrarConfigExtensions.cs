using Util.Infrastructure;

namespace Util.ObjectMapping.Infrastructure {
    /// <summary>
    /// AutoMapper服务注册器配置扩展
    /// </summary>
    public static class ServiceRegistrarConfigExtensions {
        /// <summary>
        /// 启用AutoMapper服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig EnableAutoMapperServiceRegistrar( this ServiceRegistrarConfig config ) {
            ServiceRegistrarConfig.Enable( AutoMapperServiceRegistrar.ServiceName );
            return config;
        }

        /// <summary>
        ///禁用AutoMapper服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableAutoMapperServiceRegistrar( this ServiceRegistrarConfig config ) {
            ServiceRegistrarConfig.Disable( AutoMapperServiceRegistrar.ServiceName );
            return config;
        }
    }
}
