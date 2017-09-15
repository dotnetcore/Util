using System;
using Microsoft.Extensions.Logging;
using Util.Logs.Abstractions;

namespace Util.Logs.Core {
    /// <summary>
    /// 日志操作
    /// </summary>
    /// <typeparam name="TContent">日志内容类型</typeparam>
    public abstract class LogBase<TContent> : ILog where TContent : class, ILogContent {
        /// <summary>
        /// 日志内容
        /// </summary>
        private TContent _content;
        /// <summary>
        /// 日志内容
        /// </summary>
        private TContent LogContent => _content ?? ( _content = GetContent() );
        /// <summary>
        /// 日志名称
        /// </summary>
        private readonly string _logName;

        /// <summary>
        /// 初始化日志操作
        /// </summary>
        /// <param name="provider">日志提供程序</param>
        /// <param name="context">日志上下文</param>
        /// <param name="logName">日志名称</param>
        protected LogBase( ILogProvider provider, ILogContext context, string logName ) {
            Provider = provider;
            Context = context;
            _logName = logName;
        }

        /// <summary>
        /// 日志提供程序
        /// </summary>
        public ILogProvider Provider { get; }

        /// <summary>
        /// 日志上下文
        /// </summary>
        public ILogContext Context { get; }

        /// <summary>
        /// 获取日志内容
        /// </summary>
        protected abstract TContent GetContent();

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="action">设置内容操作</param>
        public ILog Content<T>( Action<T> action ) where T : ILogContent {
            if( action == null )
                throw new ArgumentNullException( nameof( action ) );
            ILogContent logContent = LogContent;
            action( (T)logContent );
            return this;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="content">日志内容</param>
        protected virtual void Init( TContent content ) {
            content.LogName = _logName;
            content.TraceId = Context.TraceId;
            content.OperationTime = DateTime.Now.ToMillisecondString();
            content.Duration = Context.Stopwatch.Elapsed.Description();
            content.Url = Context.Url;
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
        public void Trace() {
            Execute( LogContent, LogLevel.Trace );
        }

        /// <summary>
        /// 执行
        /// </summary>
        protected virtual void Execute( TContent content, LogLevel level ) {
            try {
                Init( content );
                WriteLog( content, level );
            }
            finally {
                content = null;
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        private void WriteLog( TContent content, LogLevel level ) {
            switch( level ) {
                case LogLevel.Trace:
                    content.Level = "Trace";
                    Provider.Trace( content );
                    break;
            }
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Trace( string message, params object[] args ) {
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Trace( Exception exception, string message = "", params object[] args ) {
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Debug( string message, params object[] args ) {
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Debug( Exception exception, string message = "", params object[] args ) {
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Info( string message, params object[] args ) {
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Info( Exception exception, string message = "", params object[] args ) {
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Warn( string message, params object[] args ) {
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Warn( Exception exception, string message = "", params object[] args ) {
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Error( string message, params object[] args ) {
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Error( Exception exception, string message = "", params object[] args ) {
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Fatal( string message, params object[] args ) {
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Fatal( Exception exception, string message = "", params object[] args ) {
        }
    }
}
