using Util.Logs.Abstractions;

namespace Util.Logs.Core {
    /// <summary>
    /// 日志服务
    /// </summary>
    public abstract class LogManagerBase : ILogManager {
        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        public ILog GetLog() {
            return GetLog( string.Empty );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="instance">实例</param>
        public ILog GetLog( object instance ) {
            if( instance == null )
                return GetLog();
            var className = instance.GetType().ToString();
            return GetLog( className, className );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logName">日志名称</param>
        public ILog GetLog( string logName ) {
            return GetLog( logName, string.Empty );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logName">日志名称</param>
        /// <param name="class">类名</param>
        protected abstract ILog GetLog( string logName, string @class );
    }
}
