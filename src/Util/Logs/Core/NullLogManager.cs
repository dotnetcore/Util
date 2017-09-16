using Util.Logs.Abstractions;

namespace Util.Logs.Core {
    /// <summary>
    /// 空日志服务
    /// </summary>
    public class NullLogManager : ILogManager {
        /// <summary>
        /// 日志服务实例
        /// </summary>
        public static readonly ILogManager Instance = new NullLogManager();

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        public ILog GetLog() {
            return NullLog.Instance;
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="instance">实例</param>
        public ILog GetLog( object instance ) {
            return NullLog.Instance;
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logName">日志名称</param>
        public ILog GetLog( string logName ) {
            return NullLog.Instance;
        }
    }
}
