using System;
using Microsoft.Extensions.Logging;

namespace Util.Logging {
    /// <summary>
    /// 日志操作
    /// </summary>
    /// <typeparam name="TCategoryName">日志类别</typeparam>
    public class Log<TCategoryName> : ILog<TCategoryName> {
        /// <summary>
        /// 日志操作
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// 初始化日志操作
        /// </summary>
        /// <param name="factory">日志操作工厂</param>
        public Log( ILogFactory factory ) {
            factory.CheckNull( nameof(factory) );
            _log = factory.CreateLog(typeof( TCategoryName ) );
        }

        /// <summary>
        /// 空日志操作实例
        /// </summary>
        public static ILog<TCategoryName> Null = NullLog<TCategoryName>.Instance;

        /// <inheritdoc />
        public ILog EventId( EventId eventId ) {
            return _log.EventId( eventId );
        }

        /// <inheritdoc />
        public ILog Exception( Exception exception ) {
            return _log.Exception( exception );
        }

        /// <inheritdoc />
        public ILog Property( string propertyName, string propertyValue ) {
            return _log.Property( propertyName, propertyValue );
        }

        /// <inheritdoc />
        public ILog State( object state ) {
            return _log.State( state );
        }

        /// <inheritdoc />
        public ILog Message( string message, params object[] args ) {
            return _log.Message( message, args );
        }

        /// <inheritdoc />
        public bool IsEnabled( LogLevel logLevel ) {
            return _log.IsEnabled( logLevel );
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>( TState state ) {
            return _log.BeginScope( state );
        }

        /// <inheritdoc />
        public ILog LogTrace() {
            return _log.LogTrace();
        }

        /// <inheritdoc />
        public virtual ILog LogDebug() {
            return _log.LogDebug();
        }

        /// <inheritdoc />
        public virtual ILog LogInformation() {
            return _log.LogInformation();
        }

        /// <inheritdoc />
        public virtual ILog LogWarning() {
            return _log.LogWarning();
        }

        /// <inheritdoc />
        public virtual ILog LogError() {
            return _log.LogError();
        }

        /// <inheritdoc />
        public virtual ILog LogCritical() {
            return _log.LogCritical();
        }
    }
}
