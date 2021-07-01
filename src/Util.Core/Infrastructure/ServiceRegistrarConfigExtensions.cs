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
            config.Enable( DependencyServiceRegistrar.GetId() );
            return config;
        }

        /// <summary>
        ///禁用依赖服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableDependencyServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Disable( DependencyServiceRegistrar.GetId() );
            return config;
        }
    }
}
