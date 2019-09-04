using System;
using Microsoft.Extensions.Logging;
using Util.Logs.Abstractions;
using Util.Logs.Extensions;
using Util.Sessions;

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
        /// 初始化日志操作
        /// </summary>
        /// <param name="provider">日志提供程序</param>
        /// <param name="context">日志上下文</param>
        /// <param name="session">用户会话</param>
        protected LogBase( ILogProvider provider, ILogContext context, ISession session ) {
            Provider = provider;
            Context = context;
            Session = session ?? NullSession.Instance;
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
        /// 用户会话
        /// </summary>
        public ISession Session { get; set; }

        /// <summary>
        /// 获取日志内容
        /// </summary>
        protected abstract TContent GetContent();

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="action">设置内容操作</param>
        public ILog Set<T>( Action<T> action ) where T : ILogContent {
            if( action == null )
                throw new ArgumentNullException( nameof( action ) );
            ILogContent content = LogContent;
            action( (T)content );
            return this;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="content">日志内容</param>
        protected virtual void Init( TContent content ) {
            content.LogName = Provider.LogName;
            content.LogId = Context.LogId;
            content.TraceId = Context.TraceId;
            content.OperationTime = DateTime.Now.ToMillisecondString();
            content.Duration = Context.Stopwatch.Elapsed.Description();
            content.Ip = Context.Ip;
            content.Host = Context.Host;
            content.ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
            content.Browser = Context.Browser;
            content.Url = Context.Url;
            content.UserId = Session.UserId;
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
            _content = LogContent;
            Execute( LogLevel.Trace, ref _content );
        }

        /// <summary>
        /// 执行
        /// </summary>
        private void Execute( LogLevel level, ref TContent content ) {
            if ( content == null )
                return;
            if ( Enabled( level ) == false )
                return;
            try {
                content.Level = Util.Helpers.Enum.GetName<LogLevel>( level );
                Init( content );
                Provider.WriteLog( level, content );
            }
            finally {
                content = null;
            }
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        private bool Enabled( LogLevel level ) {
            if ( level > LogLevel.Debug )
                return true;
            return IsDebugEnabled || IsTraceEnabled && level == LogLevel.Trace;
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Trace( string message ) {
            LogContent.Content( message );
            Trace();
        }

        /// <summary>
        /// 调试
        /// </summary>
        public virtual void Debug() {
            _content = LogContent;
            Execute( LogLevel.Debug, ref _content );
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Debug( string message ) {
            LogContent.Content( message );
            Debug();
        }

        /// <summary>
        /// 信息
        /// </summary>
        public virtual void Info() {
            _content = LogContent;
            Execute( LogLevel.Information, ref _content );
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Info( string message ) {
            LogContent.Content( message );
            Info();
        }

        /// <summary>
        /// 警告
        /// </summary>
        public virtual void Warn() {
            _content = LogContent;
            Execute( LogLevel.Warning, ref _content );
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Warn( string message ) {
            LogContent.Content( message );
            Warn();
        }

        /// <summary>
        /// 错误
        /// </summary>
        public virtual void Error() {
            _content = LogContent;
            Execute( LogLevel.Error, ref _content );
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Error( string message ) {
            LogContent.Content( message );
            Error();
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        public virtual void Fatal() {
            _content = LogContent;
            Execute( LogLevel.Critical, ref _content );
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Fatal( string message ) {
            LogContent.Content( message );
            Fatal();
        }
    }
}
