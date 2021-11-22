using Util.Infrastructure;

namespace Util.Data.EntityFrameworkCore.Infrastructure {
    /// <summary>
    /// EntityFrameworkCore服务注册器配置扩展
    /// </summary>
    public static class ServiceRegistrarConfigExtensions {
        /// <summary>
        /// 启用EntityFrameworkCore服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig EnableEntityFrameworkServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Enable( EntityFrameworkServiceRegistrar.GetId() );
            return config;
        }

        /// <summary>
        ///禁用EntityFrameworkCore服务注册器
        /// </summary>
        /// <param name="config">服务注册器配置</param>
        public static ServiceRegistrarConfig DisableEntityFrameworkServiceRegistrar( this ServiceRegistrarConfig config ) {
            config.Disable( EntityFrameworkServiceRegistrar.GetId() );
            return config;
        }
    }
}
