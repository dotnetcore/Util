namespace Util.Infrastructure {
    /// <summary>
    /// 依赖服务注册器配置扩展
    /// </summary>
    public static class ServiceRegistrarConfigExtensions {
        /// <summary>
        /// 启用依赖服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig EnableDependencyServiceRegistrar( this ServiceRegistrarConfig config ) {
            ServiceRegistrarConfig.Enable( DependencyServiceRegistrar.ServiceName );
            return config;
        }

        /// <summary>
        ///禁用依赖服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableDependencyServiceRegistrar( this ServiceRegistrarConfig config ) {
            ServiceRegistrarConfig.Disable( DependencyServiceRegistrar.ServiceName );
            return config;
        }
    }
}
