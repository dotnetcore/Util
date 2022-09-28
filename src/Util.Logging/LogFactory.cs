using Microsoft.Extensions.Logging;
using System;

namespace Util.Logging {
    /// <summary>
    /// 日志操作工厂
    /// </summary>
    public class LogFactory : ILogFactory {
        /// <summary>
        /// 日志记录器工厂
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// 初始化日志操作工厂
        /// </summary>
        /// <param name="factory">日志记录器工厂</param>
        /// <exception cref="ArgumentNullException"></exception>
        public LogFactory( ILoggerFactory factory ) {
            _loggerFactory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        /// <summary>
        /// 创建日志操作
        /// </summary>
        /// <param name="categoryName">日志类别</param>
        public ILog CreateLog( string categoryName ) {
            var logger = _loggerFactory.CreateLogger( categoryName );
            var wrapper = new LoggerWrapper( logger );
            return new Log( wrapper );
        }

        /// <summary>
        /// 创建日志操作
        /// </summary>
        /// <param name="type">日志类别类型</param>
        public ILog CreateLog( Type type ) {
            var logger = _loggerFactory.CreateLogger( type );
            var wrapper = new LoggerWrapper( logger );
            return new Log( wrapper );
        }
    }
}
