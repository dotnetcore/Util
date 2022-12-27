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
        public static readonly ILog<TCategoryName> Instance = new NullLog<TCategoryName>();

        /// <inheritdoc />
        public ILog EventId( EventId eventId ) {
            return this;
        }

        /// <inheritdoc />
        public ILog Exception( Exception exception ) {
            return this;
        }

        /// <inheritdoc />
        public ILog Property( string propertyName, string propertyValue ) {
            return this;
        }

        /// <inheritdoc />
        public ILog State( object state ) {
            return this;
        }

        /// <inheritdoc />
        public ILog Message( string message, params object[] args ) {
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
        public ILog LogTrace() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogDebug() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogInformation() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogWarning() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogError() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogCritical() {
            return this;
        }
    }

    /// <summary>
    /// 空日志操作
    /// </summary>
    public class NullLog : ILog {
        /// <summary>
        /// 空日志操作实例
        /// </summary>
        public static readonly  ILog Instance = new NullLog();

        /// <inheritdoc />
        public ILog EventId( EventId eventId ) {
            return this;
        }

        /// <inheritdoc />
        public ILog Exception( Exception exception ) {
            return this;
        }

        /// <inheritdoc />
        public ILog Property( string propertyName, string propertyValue ) {
            return this;
        }

        /// <inheritdoc />
        public ILog State( object state ) {
            return this;
        }

        /// <inheritdoc />
        public ILog Message( string message, params object[] args ) {
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
        public ILog LogTrace() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogDebug() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogInformation() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogWarning() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogError() {
            return this;
        }

        /// <inheritdoc />
        public ILog LogCritical() {
            return this;
        }
    }
}
