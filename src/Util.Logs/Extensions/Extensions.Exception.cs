using System;
using Util.Exceptions;
using Util.Exceptions.Prompts;

namespace Util.Logs.Extensions {
    /// <summary>
    /// 异常扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="log">日志</param>
        public static void Log( this Exception exception, ILog log ) {
            if( exception is Warning warning ) {
                log.Exception( exception, warning.Code ).Warn();
                return;
            }
            log.Exception( exception ).Error();
        }

        /// <summary>
        /// 获取异常提示
        /// </summary>
        /// <param name="exception">异常</param>
        public static string GetPrompt( this Exception exception ) {
            return ExceptionPrompt.GetPrompt( exception );
        }
    }
}
