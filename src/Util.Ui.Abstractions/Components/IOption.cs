using System;
using Util.Ui.Configs;

namespace Util.Ui.Components {
    /// <summary>
    /// 配置项
    /// </summary>
    public interface IOption {
        /// <summary>
        /// 配置
        /// </summary>
        /// <typeparam name="TConfig">配置类型</typeparam>
        /// <param name="configAction">配置操作</param>
        void Config<TConfig>( Action<TConfig> configAction ) where TConfig : IConfig;
    }
}
