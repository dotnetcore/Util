using Util.Aop;

namespace Util.Microservices.Dapr.Events.Filters;

/// <summary>
/// 集成事件订阅异常处理过滤器
/// </summary>
public class SubscriptionExceptionHandlerAttribute : ExceptionFilterAttribute {
    /// <summary>
    /// 异常处理
    /// </summary>
    public override void OnException( ExceptionContext context ) {
        context.ExceptionHandled = true;
        var exception = context.Exception.GetRawException();
        if ( exception == null )
            return;
        if ( exception is ConcurrencyException concurrencyException ) {
            context.Result = PubsubResult.Fail( concurrencyException.Message );
            return;
        }
        if ( exception is Warning warning ) {
            context.Result = PubsubResult.Drop( warning.Message );
            return;
        }
        context.Result = PubsubResult.Fail( Warning.GetMessage( exception ) );
    }
}