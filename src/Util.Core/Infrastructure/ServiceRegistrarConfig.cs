using System;

namespace Util.Infrastructure {
    /// <summary>
    /// 服务注册器配置
    /// </summary>
    public class ServiceRegistrarConfig {
        /// <summary>
        /// 服务注册器配置实例
        /// </summary>
        public static readonly ServiceRegistrarConfig Instance = new ();

        /// <summary>
        /// 禁用服务注册器
        /// </summary>
        /// <param name="serviceName">服务注册器名称</param>
        public static void Disable( string serviceName ) {
            AppContext.SetSwitch( serviceName, false );
        }

        /// <summary>
        /// 启用服务注册器
        /// </summary>
        /// <param name="serviceName">服务注册器名称</param>
        public static void Enable( string serviceName ) {
            AppContext.SetSwitch( serviceName, true );
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="serviceName">服务注册器名称</param>
        public static bool IsEnabled( string serviceName ) {
            var result = AppContext.TryGetSwitch( serviceName, out bool isEnabled );
            if ( result && isEnabled == false )
                return false;
            return true;
        }
    }
}
