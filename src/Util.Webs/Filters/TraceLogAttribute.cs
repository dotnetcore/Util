using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Webs.Commons;

namespace Util.Webs.Filters {
    /// <summary>
    /// 跟踪日志过滤器
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method )]
    public class TraceLogAttribute : ActionFilterAttribute {
        /// <summary>
        /// 日志名
        /// </summary>
        public const string TraceLogName = "ApiTraceLog";

        /// <summary>
        /// 是否忽略,为true不记录日志
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        public override async Task OnActionExecutionAsync( ActionExecutingContext context, ActionExecutionDelegate next ) {
            if( context == null )
                throw new ArgumentNullException( nameof( context ) );
            if( next == null )
                throw new ArgumentNullException( nameof( next ) );
            var log = GetLog();
            OnActionExecuting( context );
            await OnActionExecutingAsync( context, log );
            if( context.Result != null )
                return;
            var executedContext = await next();
            OnActionExecuted( executedContext );
            OnActionExecuted( executedContext, log );
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog() {
            try {
                return Log.GetLog( TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }

        /// <summary>
        /// 执行前
        /// </summary>
        protected virtual async Task OnActionExecutingAsync( ActionExecutingContext context,ILog log ) {
            if( Ignore )
                return;
            if( log.IsTraceEnabled == false )
                return;
            await WriteLog( context, log );
        }

        /// <summary>
        /// 执行前日志
        /// </summary>
        private async Task WriteLog( ActionExecutingContext context, ILog log ) {
            log.Caption( "WebApi跟踪-准备执行操作" )
                .Class( context.Controller.SafeString() )
                .Method( context.ActionDescriptor.DisplayName );
            await AddRequestInfo( context,log );
            log.Trace();
        }

        /// <summary>
        /// 添加请求信息参数
        /// </summary>
        private async Task AddRequestInfo( ActionExecutingContext context, ILog log ) {
            var request = context.HttpContext.Request;
            log.Params( "Http请求方式", request.Method );
            if( string.IsNullOrWhiteSpace( request.ContentType ) == false )
                log.Params( "ContentType", request.ContentType );
            await AddFormParams( request, log );
            AddCookie( request, log );
        }

        /// <summary>
        /// 添加表单参数
        /// </summary>
        private async Task AddFormParams( Microsoft.AspNetCore.Http.HttpRequest request, ILog log ) {
            if( IsMultipart( request.ContentType ) )
                return;
            request.EnableRewind();
            var result = await File.ToStringAsync( request.Body, isCloseStream: false );
            if( string.IsNullOrWhiteSpace( result ) )
                return;
            log.Params( "表单参数:" ).Params( result );
        }

        /// <summary>
        /// 是否multipart内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        private static bool IsMultipart( string contentType ) {
            if( string.IsNullOrWhiteSpace( contentType ) )
                return false;
            return contentType.IndexOf( "multipart/", StringComparison.OrdinalIgnoreCase ) >= 0;
        }

        /// <summary>
        /// 添加Cookie
        /// </summary>
        private void AddCookie( Microsoft.AspNetCore.Http.HttpRequest request, ILog log ) {
            log.Params( "Cookie:" );
            foreach( var key in request.Cookies.Keys )
                log.Params( key, request.Cookies[key] );
        }

        /// <summary>
        /// 执行后
        /// </summary>
        protected virtual void OnActionExecuted( ActionExecutedContext context, ILog log ) {
            if( Ignore )
                return;
            if( log.IsTraceEnabled == false )
                return;
            WriteLog( context, log );
        }

        /// <summary>
        /// 执行后日志
        /// </summary>
        private void WriteLog( ActionExecutedContext context, ILog log ) {
            log.Caption( "WebApi跟踪-执行操作完成" )
                .Class( context.Controller.SafeString() )
                .Method( context.ActionDescriptor.DisplayName );
            AddResponseInfo( context, log );
            AddResult( context, log );
            log.Trace();
        }

        /// <summary>
        /// 添加响应信息参数
        /// </summary>
        private void AddResponseInfo( ActionExecutedContext context, ILog log ) {
            var response = context.HttpContext.Response;
            if( string.IsNullOrWhiteSpace( response.ContentType ) == false )
                log.Content( $"ContentType: {response.ContentType}" );
            log.Content( $"Http状态码: {response.StatusCode}" );
        }

        /// <summary>
        /// 记录响应结果
        /// </summary>
        private void AddResult( ActionExecutedContext context, ILog log ) {
            if( !( context.Result is Result result ) )
                return;
            log.Content( $"响应消息: { result.Message}" )
                .Content( "响应结果:" )
                .Content( $"{Json.ToJson( result.Data )}" );
        }
    }
}
