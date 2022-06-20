using System;
using Microsoft.Extensions.Logging;

namespace Util.Logging {
    /// <summary>
    /// 空日志操作
    /// </summary>
    /// <typeparam name="TCategoryName">日志类别</typeparam>
    public class NullLog<TCategoryName> : ILog<TCategoryName> {
        /// <summary>
        /// 空日志操作实例
        /// </summary>
        public static readonly  ILog<TCategoryName> Instance = new NullLog<TCategoryName>();

        /// <inheritdoc />
        public ILog<TCategoryName> EventId( EventId eventId ) {
            return this;
        }

        /// <inheritdoc />
        public ILog<TCategoryName> Exception( Exception exception ) {
            return this;
        }

        /// <inheritdoc />
        public ILog<TCategoryName> Property( string propertyName, string propertyValue ) {
            return this;
        }

        /// <inheritdoc />
        public ILog<TCategoryName> State( object state ) {
            return this;
        }

        /// <inheritdoc />
        public ILog<TCategoryName> Message( string message, params object[] args ) {
            return this;
        }

        /// <inheritdoc />
        public bool IsEnabled( LogLevel logLevel ) {
            return false;
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>( TState state ) {
            return new DisposeAction( () => { } );
        }

        /// <inheritdoc />
        public ILog<TCategoryName> LogTrace() {
            return this;
        }

        /// <inheritdoc />
        public ILog<TCategoryName> LogDebug() {
            return this;
        }

        /// <inheritdoc />
        public ILog<TCategoryName> LogInformation() {
            return this;
        }

        /// <inheritdoc />
        public ILog<TCategoryName> LogWarning() {
            return this;
        }

        /// <inheritdoc />
        public ILog<TCategoryName> LogError() {
            return this;
        }

        /// <inheritdoc />
        public ILog<TCategoryName> LogCritical() {
            return this;
        }
    }
}
