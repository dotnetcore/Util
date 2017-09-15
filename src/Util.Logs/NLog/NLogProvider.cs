using System;
using NLog;
using Util.Logs.Abstractions;
using Util.Logs.Formats;

namespace Util.Logs.NLog {
    /// <summary>
    /// NLog日志提供程序
    /// </summary>
    public class NLogProvider : ILogProvider {
        /// <summary>
        /// NLog日志操作
        /// </summary>
        private readonly Logger _logger;
        /// <summary>
        /// 日志格式化器
        /// </summary>
        private readonly ILogFormat _format;

        /// <summary>
        /// 初始化日志
        /// </summary>
        /// <param name="logger">NLog日志操作</param>
        /// <param name="format">日志格式化器</param>
        public NLogProvider( Logger logger ,ILogFormat format = null ) {
            _logger = logger;
            _format = format;
        }

        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        public bool IsTraceEnabled => _logger.IsTraceEnabled;

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Trace( object message ) {
            var provider = GetFormatProvider();
            if ( provider == null ) {
                _logger.Trace( message );
                return;
            }
            _logger.Trace( provider, message );
        }

        /// <summary>
        /// 获取格式化提供程序
        /// </summary>
        private IFormatProvider GetFormatProvider() {
            if ( _format == null )
                return null;
            return new FormatProvider( _format );
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Debug( object message ) {
            var provider = GetFormatProvider();
            if( provider == null ) {
                _logger.Debug( message );
                return;
            }
            _logger.Debug( provider, message );
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Info( object message ) {
            var provider = GetFormatProvider();
            if( provider == null ) {
                _logger.Info( message );
                return;
            }
            _logger.Info( provider, message );
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Warn( object message ) {
            var provider = GetFormatProvider();
            if( provider == null ) {
                _logger.Warn( message );
                return;
            }
            _logger.Warn( provider, message );
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Error( object message ) {
            var provider = GetFormatProvider();
            if( provider == null ) {
                _logger.Error( message );
                return;
            }
            _logger.Error( provider, message );
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Fatal( object message ) {
            var provider = GetFormatProvider();
            if( provider == null ) {
                _logger.Fatal( message );
                return;
            }
            _logger.Fatal( provider, message );
        }
    }
}
