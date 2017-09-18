using Microsoft.Extensions.Logging;

namespace Util.Logs.Abstractions {
    /// <summary>
    /// 日志提供程序
    /// </summary>
    public interface ILogProvider {
        /// <summary>
        /// 日志名称
        /// </summary>
        string LogName { get; }
        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        bool IsDebugEnabled { get; }
        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        bool IsTraceEnabled { get; }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="level">日志等级</param>
        /// <param name="content">日志内容</param>
        void WriteLog( LogLevel level, ILogContent content );
    }
}
