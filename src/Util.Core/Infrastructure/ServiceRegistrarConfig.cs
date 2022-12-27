using System.Collections.Generic;

namespace Util.Infrastructure {
    /// <summary>
    /// 服务注册器配置
    /// </summary>
    public class ServiceRegistrarConfig {
        /// <summary>
        /// 服务启用配置
        /// </summary>
        private IDictionary<int, bool> _serviceEnabledConfig;

        /// <summary>
        /// 初始化服务注册器配置
        /// </summary>
        public ServiceRegistrarConfig() {
            Init();
        }
        
        /// <summary>
        /// 服务注册器配置实例
        /// </summary>
        public static readonly ServiceRegistrarConfig Instance = new ServiceRegistrarConfig();

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            _serviceEnabledConfig = new Dictionary<int, bool>();
        }

        /// <summary>
        /// 禁用服务注册器
        /// </summary>
        /// <param name="id">服务注册器标识</param>
        public void Disable( int id ) {
            _serviceEnabledConfig[id] = false;
        }

        /// <summary>
        /// 启用服务注册器
        /// </summary>
        /// <param name="id">服务注册器标识</param>
        public void Enable( int id ) {
            _serviceEnabledConfig[id] = true;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="id">服务注册器标识</param>
        public bool IsEnabled( int id ) {
            if ( _serviceEnabledConfig.ContainsKey( id ) )
                return _serviceEnabledConfig[id];
            return true;
        }
    }
}
