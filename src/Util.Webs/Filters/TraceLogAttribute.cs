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
        /// 日志
        /// </summary>
        private ILog Logger { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        public override async Task OnActionExecutionAsync( ActionExecutingContext context, ActionExecutionDelegate next ) {
            if( context == null )
                throw new ArgumentNullException( nameof( context ) );
            if( next == null )
                throw new ArgumentNullException( nameof( next ) );
            ActionFilterAttribute actionFilterAttribute = this;
            actionFilterAttribute.OnActionExecuting( context );
            await OnActionExecutingAsync( context );
            if( context.Result != null )
                return;
            var executedContext = await next();
            actionFilterAttribute.OnActionExecuted( executedContext );
        }

        /// <summary>
        /// 执行前
        /// </summary>
        protected async Task OnActionExecutingAsync( ActionExecutingContext context ) {
            if( Ignore )
                return;
            Logger = GetLog();
            if( Logger.IsTraceEnabled == false )
                return;
            await WriteLog( context );
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
        /// 执行前日志
        /// </summary>
        private async Task WriteLog( ActionExecutingContext context ) {
            Logger.Caption( "WebApi跟踪-准备执行操作" )
                .Class( context.Controller.SafeString() )
                .Method( context.ActionDescriptor.DisplayName );
            await AddRequestInfo( context );
            Logger.Trace();
        }

        /// <summary>
        /// 添加请求信息参数
        /// </summary>
        private async Task AddRequestInfo( ActionExecutingContext context ) {
            var request = context.HttpContext.Request;
            Logger.Params( "Http请求方式", request.Method );
            if( string.IsNullOrWhiteSpace( request.ContentType ) == false )
                Logger.Params( "ContentType", request.ContentType );
            await AddFormParams( request );
            AddCookie( request );
        }

        /// <summary>
        /// 添加表单参数
        /// </summary>
        private async Task AddFormParams( Microsoft.AspNetCore.Http.HttpRequest request ) {
            if( IsMultipart( request.ContentType ) )
                return;
            request.EnableRewind();
            var result = await File.ToStringAsync( request.Body, isCloseStream: false );
            if( string.IsNullOrWhiteSpace( result ) )
                return;
            Logger.Params( "表单参数:" ).Params( result );
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
        private void AddCookie( Microsoft.AspNetCore.Http.HttpRequest request ) {
            Logger.Params( "Cookie:" );
            foreach( var key in request.Cookies.Keys )
                Logger.Params( key, request.Cookies[key] );
        }

        /// <summary>
        /// 执行后
        /// </summary>
        public override void OnActionExecuted( ActionExecutedContext context ) {
            if( Ignore )
                return;
            if( Logger.IsTraceEnabled == false )
                return;
            WriteLog( context );
        }

        /// <summary>
        /// 执行后日志
        /// </summary>
        private void WriteLog( ActionExecutedContext context ) {
            Logger.Caption( "WebApi跟踪-执行操作完成" )
                .Class( context.Controller.SafeString() )
                .Method( context.ActionDescriptor.DisplayName );
            AddResponseInfo( context );
            AddResult( context );
            Logger.Trace();
        }

        /// <summary>
        /// 添加响应信息参数
        /// </summary>
        private void AddResponseInfo( ActionExecutedContext context ) {
            var response = context.HttpContext.Response;
            if( string.IsNullOrWhiteSpace( response.ContentType ) == false )
                Logger.Content( $"ContentType: {response.ContentType}" );
            Logger.Content( $"Http状态码: {response.StatusCode}" );
        }

        /// <summary>
        /// 记录响应结果
        /// </summary>
        private void AddResult( ActionExecutedContext context ) {
            if( !( context.Result is Result result ) )
                return;
            Logger.Content( $"响应消息: { result.Message}" )
                .Content( "响应结果:" )
                .Content( $"{Json.ToJson( result.Data )}" );
        }
    }
}
