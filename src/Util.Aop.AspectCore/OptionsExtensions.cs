using System;
using AspectCore.Configuration;
using Util.Configs;

namespace Util.Aop {
    /// <summary>
    /// Aop配置扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 启用AspectCore拦截器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">AspectCore拦截器配置操作</param>
        public static Options UseAop( this Options options, Action<IAspectConfiguration> setupAction = null ) {
            options.AddExtension( new AopOptionsExtension( setupAction ) );
            return options;
        }
    }
}
