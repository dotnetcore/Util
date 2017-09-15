using Util.Logs.Abstractions;

namespace Util.Logs {
    /// <summary>
    /// 日志服务
    /// </summary>
    public interface ILogManager {
        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        ILog GetLog();
        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="instance">实例</param>
        ILog GetLog( object instance );
        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logName">日志名称</param>
        ILog GetLog( string logName );
    }
}
