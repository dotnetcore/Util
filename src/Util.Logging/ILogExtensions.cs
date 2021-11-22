using System;

namespace Util.Logging {
    /// <summary>
    /// Serilog日志操作扩展
    /// </summary>
    public static class ILogExtensions {
        /// <summary>
        /// 消息换行
        /// </summary>
        /// <param name="log">配置项</param>
        public static ILog<TCategoryName> Line<TCategoryName>( this ILog<TCategoryName> log ) {
            log.Message( Environment.NewLine );
            return log;
        }
    }
}
