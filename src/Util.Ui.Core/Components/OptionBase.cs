using System;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;

namespace Util.Ui.Components {
    /// <summary>
    /// 配置项
    /// </summary>
    public abstract class OptionBase<TConfig> : IOption, IOptionConfig where TConfig : class, IConfig {
        /// <summary>
        /// 控件跟踪日志名
        /// </summary>
        protected const string TraceLogName = "UiControlTraceLog";

        /// <summary>
        /// 配置
        /// </summary>
        private TConfig _config;

        /// <summary>
        /// 配置
        /// </summary>
        protected TConfig OptionConfig => _config ?? ( _config = GetConfig() );

        /// <summary>
        /// 获取配置
        /// </summary>
        protected abstract TConfig GetConfig();

        /// <summary>
        /// 配置
        /// </summary>
        /// <typeparam name="TComponentConfig">配置类型</typeparam>
        /// <param name="configAction">配置方法</param>
        public void Config<TComponentConfig>( Action<TComponentConfig> configAction ) where TComponentConfig : IConfig {
            if( configAction == null )
                throw new ArgumentNullException( nameof( configAction ) );
            IConfig config = OptionConfig;
            configAction( (TComponentConfig)config );
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog( string caption ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( caption )
                .Content( ToString() )
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog() {
            try {
                return Log.GetLog( TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }
    }
}
