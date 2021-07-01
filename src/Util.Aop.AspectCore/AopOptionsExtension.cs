using System;
using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Util.Configs;

namespace Util.Aop {
    /// <summary>
    /// Aop配置项扩展
    /// </summary>
    public class AopOptionsExtension : IOptionsExtension {
        /// <summary>
        /// Aop配置
        /// </summary>
        private readonly Action<IAspectConfiguration> _configure;

        /// <summary>
        /// 初始化Aop配置项扩展
        /// </summary>
        /// <param name="configure">Aop配置</param>
        public AopOptionsExtension( Action<IAspectConfiguration> configure ) {
            _configure = configure;
        }

        /// <summary>
        /// 添加服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public void AddServices( IServiceCollection services ) {
            services.ConfigureDynamicProxy( _configure );
        }
    }
}
