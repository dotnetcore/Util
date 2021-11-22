using System;
using Exceptionless;

namespace Util.Logging.Serilog {
    /// <summary>
    /// Serilog Exceptionless日志配置
    /// </summary>
    public class SerilogExceptionlessConfiguration {
        /// <summary>
        /// 添加Exceptionless日志组件
        /// </summary>
        public void AddExceptionless() {
        }

        /// <summary>
        /// 添加Exceptionless日志组件
        /// </summary>
        /// <param name="configAction">Exceptionless日志配置操作</param>
        public void AddExceptionless( Action<ExceptionlessConfiguration> configAction ) {
            ConfigAction = configAction;
        }

        /// <summary>
        /// Exceptionless日志配置操作
        /// </summary>
        internal Action<ExceptionlessConfiguration> ConfigAction { get; private set; }
    }
}
