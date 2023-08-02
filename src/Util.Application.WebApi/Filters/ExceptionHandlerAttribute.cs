using Util.Helpers;
using Util.Exceptions;
using Util.AspNetCore;

namespace Util.Applications.Filters; 

/// <summary>
/// 异常处理过滤器
/// </summary>
public class ExceptionHandlerAttribute : ExceptionFilterAttribute {
    /// <summary>
    /// 异常处理
    /// </summary>
    public override void OnException( ExceptionContext context ) {
        context.ExceptionHandled = true;
        var message = context.Exception.GetPrompt( Web.Environment.IsProduction() );
        message = GetLocalizedMessages( context, message );
        var errorCode = context.Exception.GetErrorCode() ?? StateCode.Fail;
        var httpStatusCode = context.Exception.GetHttpStatusCode() ?? 200;
        context.Result = GetResult( context, errorCode, message, httpStatusCode );
    }

    /// <summary>
    /// 获取本地化异常消息
    /// </summary>
    protected virtual string GetLocalizedMessages( ExceptionContext context, string message ) {
        var exception = context.Exception.GetRawException();
        if ( exception is Warning { IsLocalization: false } ) 
            return message;
        var stringLocalizerFactory = context.HttpContext.RequestServices.GetService<IStringLocalizerFactory>();
        if ( stringLocalizerFactory == null )
            return message;
        var stringLocalizer = stringLocalizerFactory.Create( "Warning",null );
        var localizedString = stringLocalizer[message];
        if ( localizedString.ResourceNotFound == false )
            return localizedString.Value;
        stringLocalizer = context.HttpContext.RequestServices.GetService<IStringLocalizer>();
        if ( stringLocalizer == null )
            return message;
        return stringLocalizer[message];
    }

    /// <summary>
    /// 获取结果
    /// </summary>
    protected virtual IActionResult GetResult( ExceptionContext context, string code, string message, int? httpStatusCode ) {
        var options = GetJsonSerializerOptions( context );
        var resultFactory = context.HttpContext.RequestServices.GetService<IResultFactory>();
        if ( resultFactory == null )
            return new Result( code, message, null, httpStatusCode, options );
        return resultFactory.CreateResult( code, message, null, httpStatusCode, options );
    }

    /// <summary>
    /// 获取Json序列化配置
    /// </summary>
    private JsonSerializerOptions GetJsonSerializerOptions( ExceptionContext context ) {
        var factory = context.HttpContext.RequestServices.GetService<IJsonSerializerOptionsFactory>();
        factory.CheckNull( nameof( factory ) );
        return factory.CreateOptions();
    }
}