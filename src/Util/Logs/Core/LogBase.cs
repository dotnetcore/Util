using System;

namespace Util.Logs.Core {
    /// <summary>
    /// 日志操作
    /// </summary>
    public abstract class LogBase : ILog {
        /// <summary>
        /// 初始化日志操作
        /// </summary>
        /// <param name="provider">日志提供程序</param>
        protected LogBase( ILogProvider provider ) {
            Provider = provider;
        }

        /// <summary>
        /// 日志提供程序
        /// </summary>
        protected ILogProvider Provider { get; }

        /// <summary>
        /// 日志内容
        /// </summary>
        private ILogContent LogContent => _content ?? ( _content = GetContent() );

        /// <summary>
        /// 日志内容
        /// </summary>
        private ILogContent _content;

        /// <summary>
        /// 获取日志内容
        /// </summary>
        protected abstract ILogContent GetContent();

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <typeparam name="TContent">内容类型</typeparam>
        /// <param name="action">设置内容操作</param>
        public ILog Content<TContent>( Action<TContent> action ) where TContent : ILogContent {
            if( action == null )
                throw new ArgumentNullException( nameof( action ) );
            action( (TContent)LogContent );
            return this;
        }

        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        public bool IsDebugEnabled => Provider.IsDebugEnabled;

        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        public bool IsTraceEnabled => Provider.IsTraceEnabled;

        /// <summary>
        /// 跟踪
        /// </summary>
        public virtual void Trace() {
            Provider.Trace( GetContent() );
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Trace( string message, params object[] args ) {
            Provider.Trace( message, args );
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Trace( Exception exception, string message = "", params object[] args ) {
            Provider.Trace( exception, message, args );
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Debug( string message, params object[] args ) {
            Provider.Debug( message, args );
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Debug( Exception exception, string message = "", params object[] args ) {
            Provider.Debug( exception, message, args );
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Info( string message, params object[] args ) {
            Provider.Info( message, args );
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Info( Exception exception, string message = "", params object[] args ) {
            Provider.Info( exception, message, args );
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Warn( string message, params object[] args ) {
            Provider.Warn( message, args );
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Warn( Exception exception, string message = "", params object[] args ) {
            Provider.Warn( exception, message, args );
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Error( string message, params object[] args ) {
            Provider.Error( message, args );
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Error( Exception exception, string message = "", params object[] args ) {
            Provider.Error( exception, message, args );
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Fatal( string message, params object[] args ) {
            Provider.Fatal( message, args );
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Fatal( Exception exception, string message = "", params object[] args ) {
            Provider.Fatal( exception, message, args );
        }
    }
}
