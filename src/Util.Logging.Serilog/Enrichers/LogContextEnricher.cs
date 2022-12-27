using Serilog.Core;
using Serilog.Events;
using Util.Helpers;

namespace Util.Logging.Serilog.Enrichers {
    /// <summary>
    /// 日志上下文扩展属性
    /// </summary>
    public class LogContextEnricher : ILogEventEnricher {
        /// <summary>
        /// 日志上下文
        /// </summary>
        private LogContext _context;

        /// <summary>
        /// 扩展属性
        /// </summary>
        /// <param name="logEvent">日志事件</param>
        /// <param name="propertyFactory">日志事件属性工厂</param>
        public void Enrich( LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
            var accessor = Ioc.Create<ILogContextAccessor>();
            if ( accessor == null )
                return;
            _context = accessor.Context;
            if ( _context == null )
                return;
            RemoveProperties( logEvent );
            AddDuration( logEvent, propertyFactory );
            AddTraceId( logEvent, propertyFactory );
            AddUserId( logEvent, propertyFactory );
            AddApplication( logEvent, propertyFactory );
            AddEnvironment( logEvent, propertyFactory );
            AddData( logEvent, propertyFactory );
        }

        /// <summary>
        /// 移除默认设置的部分属性
        /// </summary>
        private void RemoveProperties( LogEvent logEvent ) {
            logEvent.RemovePropertyIfPresent( "ActionId" );
            logEvent.RemovePropertyIfPresent( "ActionName" );
            logEvent.RemovePropertyIfPresent( "RequestId" );
            logEvent.RemovePropertyIfPresent( "RequestPath" );
            logEvent.RemovePropertyIfPresent( "ConnectionId" );
        }

        /// <summary>
        /// 添加执行持续时间
        /// </summary>
        private void AddDuration( LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
            if ( _context.Stopwatch == null )
                return;
            var property = propertyFactory.CreateProperty( "Duration", _context.Stopwatch.Elapsed.Description() );
            logEvent.AddOrUpdateProperty( property );
        }

        /// <summary>
        /// 添加跟踪号
        /// </summary>
        private void AddTraceId( LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
            if ( _context.TraceId.IsEmpty() )
                return;
            var property = propertyFactory.CreateProperty( "TraceId", _context.TraceId );
            logEvent.AddOrUpdateProperty( property );
        }

        /// <summary>
        /// 添加用户标识
        /// </summary>
        private void AddUserId( LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
            if ( _context.UserId.IsEmpty() )
                return;
            var property = propertyFactory.CreateProperty( "UserId", _context.UserId );
            logEvent.AddOrUpdateProperty( property );
        }

        /// <summary>
        /// 添加应用程序
        /// </summary>
        private void AddApplication( LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
            if ( _context.Application.IsEmpty() )
                return;
            var property = propertyFactory.CreateProperty( "Application", _context.Application );
            logEvent.AddOrUpdateProperty( property );
        }

        /// <summary>
        /// 添加执行环境
        /// </summary>
        private void AddEnvironment( LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
            if ( _context.Environment.IsEmpty() )
                return;
            var property = propertyFactory.CreateProperty( "Environment", _context.Environment );
            logEvent.AddOrUpdateProperty( property );
        }

        /// <summary>
        /// 添加扩展数据
        /// </summary>
        private void AddData( LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
            if ( _context.Data.Count == 0 )
                return;
            foreach ( var item in _context.Data ) {
                var property = propertyFactory.CreateProperty( item.Key, item.Value );
                logEvent.AddOrUpdateProperty( property );
            }
        }
    }
}
