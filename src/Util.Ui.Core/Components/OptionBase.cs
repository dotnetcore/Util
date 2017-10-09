using System;
using Util.Ui.Configs;

namespace Util.Ui.Components {
    /// <summary>
    /// 配置项
    /// </summary>
    public abstract class OptionBase : IOption {
        /// <summary>
        /// 配置
        /// </summary>
        private IConfig _config;

        /// <summary>
        /// 配置
        /// </summary>
        protected IConfig OptionConfig => _config ?? ( _config = GetConfig() );

        /// <summary>
        /// 获取配置
        /// </summary>
        protected virtual IConfig GetConfig() {
            return new Config();
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <typeparam name="TConfig">配置类型</typeparam>
        /// <param name="configAction">配置方法</param>
        public void Config<TConfig>( Action<TConfig> configAction ) where TConfig : IConfig {
            if( configAction == null )
                throw new ArgumentNullException( nameof( configAction ) );
            configAction( (TConfig)OptionConfig );
        }
    }
}
