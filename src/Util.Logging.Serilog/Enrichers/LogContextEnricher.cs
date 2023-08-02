using Util.Helpers;

namespace Util.Logging.Serilog.Enrichers; 

/// <summary>
/// 日志上下文扩展属性
/// </summary>
public class LogContextEnricher : ILogEventEnricher {
    /// <summary>
    /// 扩展属性
    /// </summary>
    /// <param name="logEvent">日志事件</param>
    /// <param name="propertyFactory">日志事件属性工厂</param>
    public void Enrich( LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
        var accessor = Ioc.Create<ILogContextAccessor>();
        if ( accessor == null )
            return;
        var context = accessor.Context;
        if ( context == null )
            return;
        if ( logEvent == null )
            return;
        if ( propertyFactory == null )
            return;
        RemoveProperties( logEvent );
        AddDuration( context,logEvent, propertyFactory );
        AddTraceId( context, logEvent, propertyFactory );
        AddUserId( context, logEvent, propertyFactory );
        AddApplication( context, logEvent, propertyFactory );
        AddEnvironment( context, logEvent, propertyFactory );
        AddData( context, logEvent, propertyFactory );
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
    private void AddDuration( LogContext context, LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
        if ( context?.Stopwatch == null )
            return;
        var property = propertyFactory.CreateProperty( "Duration", context.Stopwatch.Elapsed.Description() );
        logEvent.AddOrUpdateProperty( property );
    }

    /// <summary>
    /// 添加跟踪号
    /// </summary>
    private void AddTraceId( LogContext context, LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
        if ( context == null || context.TraceId.IsEmpty() )
            return;
        var property = propertyFactory.CreateProperty( "TraceId", context.TraceId );
        logEvent.AddOrUpdateProperty( property );
    }

    /// <summary>
    /// 添加用户标识
    /// </summary>
    private void AddUserId( LogContext context, LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
        if ( context == null || context.UserId.IsEmpty() )
            return;
        var property = propertyFactory.CreateProperty( "UserId", context.UserId );
        logEvent.AddOrUpdateProperty( property );
    }

    /// <summary>
    /// 添加应用程序
    /// </summary>
    private void AddApplication( LogContext context, LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
        if ( context == null || context.Application.IsEmpty() )
            return;
        var property = propertyFactory.CreateProperty( "Application", context.Application );
        logEvent.AddOrUpdateProperty( property );
    }

    /// <summary>
    /// 添加执行环境
    /// </summary>
    private void AddEnvironment( LogContext context, LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
        if ( context == null || context.Environment.IsEmpty() )
            return;
        var property = propertyFactory.CreateProperty( "Environment", context.Environment );
        logEvent.AddOrUpdateProperty( property );
    }

    /// <summary>
    /// 添加扩展数据
    /// </summary>
    private void AddData( LogContext context, LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
        if ( context?.Data == null || context.Data.Count == 0 )
            return;
        foreach ( var item in context.Data ) {
            var property = propertyFactory.CreateProperty( item.Key, item.Value );
            logEvent.AddOrUpdateProperty( property );
        }
    }
}