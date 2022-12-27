using System;

namespace Util.Logging {
    /// <summary>
    /// 日志操作扩展
    /// </summary>
    public static class ILogExtensions {
        /// <summary>
        /// 添加消息
        /// </summary>
        /// <param name="log">配置项</param>
        /// <param name="message">消息</param>
        /// <param name="args">日志消息参数</param>
        public static ILog Append( this ILog log,string message, params object[] args ) {
            log.CheckNull( nameof( log ) );
            log.Message( message, args );
            return log;
        }

        /// <summary>
        /// 当条件为true添加消息
        /// </summary>
        /// <param name="log">配置项</param>
        /// <param name="message">消息</param>
        /// <param name="condition">条件,值为true则添加消息</param>
        /// <param name="args">日志消息参数</param>
        public static ILog AppendIf( this ILog log, string message,bool condition, params object[] args ) {
            log.CheckNull( nameof( log ) );
            if ( condition )
                log.Message( message, args );
            return log;
        }

        /// <summary>
        /// 添加消息并换行
        /// </summary>
        /// <param name="log">配置项</param>
        /// <param name="message">消息</param>
        /// <param name="args">日志消息参数</param>
        public static ILog AppendLine( this ILog log, string message, params object[] args ) {
            log.CheckNull( nameof( log ) );
            log.Message( message, args );
            log.Message( Environment.NewLine );
            return log;
        }

        /// <summary>
        /// 当条件为true添加消息并换行
        /// </summary>
        /// <param name="log">配置项</param>
        /// <param name="message">消息</param>
        /// <param name="condition">条件,值为true则添加消息</param>
        /// <param name="args">日志消息参数</param>
        public static ILog AppendLineIf( this ILog log, string message, bool condition, params object[] args ) {
            log.CheckNull( nameof( log ) );
            if ( condition ) {
                log.Message( message, args );
                log.Message( Environment.NewLine );
            }
            return log;
        }

        /// <summary>
        /// 消息换行
        /// </summary>
        /// <param name="log">配置项</param>
        public static ILog Line( this ILog log ) {
            log.CheckNull( nameof(log) );
            log.Message( Environment.NewLine );
            return log;
        }
    }
}
