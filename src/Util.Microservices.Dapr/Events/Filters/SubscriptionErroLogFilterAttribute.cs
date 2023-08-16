using Microsoft.AspNetCore.Mvc.Filters;
using Util.Aop;

namespace Util.Microservices.Dapr.Events.Filters; 

/// <summary>
/// 集成事件订阅错误日志过滤器
/// </summary>
public class SubscriptionErroLogFilterAttribute : ExceptionFilterAttribute {
    /// <summary>
    /// 异常处理
    /// </summary>
    public override void OnException( ExceptionContext context ) {
        if( context == null )
            return;
        var log = context.HttpContext.RequestServices.GetService<ILogger<SubscriptionErroLogFilterAttribute>>();
        var exception = context.Exception.GetRawException();
        if( exception is Warning warning ) {
            log.LogWarning( warning, exception.Message );
            return;
        }
        log.LogError( exception, exception.Message );
    }
}