using System;
using AspectCore.Configuration;
using Util.Configs;

namespace Util.Aop {
    /// <summary>
    /// Aop配置扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置拦截器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="configure">Aop配置</param>
        public static Options UseAop( this Options options, Action<IAspectConfiguration> configure = null ) {
            options.AddExtension( new AopOptionsExtension( configure ) );
            return options;
        }
    }
}
