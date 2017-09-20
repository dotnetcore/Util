using Microsoft.Extensions.Logging;
using Util.Logs.Abstractions;

namespace Util.Logs.Aspects {
    /// <summary>
    /// 调试日志
    /// </summary>
    public class DebugLogAttribute : LogAttributeBase {
        /// <summary>
        /// 是否启用
        /// </summary>
        protected override bool Enabled( ILog log ) {
            return log.IsDebugEnabled;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected override void WriteLog( ILog log ) {
            log.Debug();
            LogLevel
        }
    }
}
