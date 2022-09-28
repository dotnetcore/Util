using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Util.Helpers;
using Util.Logging;

namespace Util.Ui.TagHelpers {
    /// <summary>
    /// TagHelper基类
    /// </summary>
    public abstract class TagHelperBase : TagHelper {
        /// <summary>
        /// 跟踪日志分类
        /// </summary>
        public const string TraceLogCategory = "Util.Ui.TagHelper";
        /// <summary>
        /// 日志缓存列表,用于排除重复日志记录
        /// </summary>
        private static readonly ConcurrentDictionary<string, DateTime> _logs = new();
        /// <summary>
        /// 是否写跟踪日志
        /// </summary>
        public bool WriteLog { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// style,样式
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// class,样式类
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// [hidden],是否隐藏
        /// </summary>
        public string Hidden { get; set; }

        /// <summary>
        /// 转换为包装器
        /// </summary>
        public TagHelperWrapper ToWrapper() {
            return new TagHelperWrapper( this );
        }

        /// <summary>
        /// 转换为包装器
        /// </summary>
        public TagHelperWrapper<TModel> ToWrapper<TModel>() {
            return new TagHelperWrapper<TModel>( this );
        }

        /// <summary>
        /// 渲染
        /// </summary>
        public override async Task ProcessAsync( TagHelperContext context, TagHelperOutput output ) {
            ProcessBefore( context, output );
            var content = await output.GetChildContentAsync();
            var render = GetRender( context, output, content );
            output.SuppressOutput();
            output.PostElement.SetHtmlContent( render );
            ProcessAfter( context, output, content, render );
        }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        protected virtual void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        /// <param name="content">内容</param>
        protected abstract IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content );

        /// <summary>
        /// 渲染后操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        /// <param name="content">内容</param>
        /// <param name="render">渲染器</param>
        protected virtual void ProcessAfter( TagHelperContext context, TagHelperOutput output, TagHelperContent content, IHtmlContent render ) {
            if ( WriteLog )
                WriteTraceLog( render );
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteTraceLog( IHtmlContent render ) {
            var log = GetLog();
            if ( log.IsEnabled( LogLevel.Trace ) == false )
                return;
            var content = GetContent( render );
            if ( content == null )
                return;
            var key = content.GetHashCode().ToString();
            if ( IsIgnoreLog( key ) )
                return;
            log.AppendLine( $"Url: {Web.Url}" )
                .AppendLine( $"TagHelper: {GetType().FullName}" )
                .AppendLine( content )
                .LogTrace();
            _logs.AddOrUpdate( key, ( t ) => DateTime.Now, ( t1, t2 ) => DateTime.Now );
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog() {
            try {
                var factory = Ioc.Create<ILogFactory>();
                return factory?.CreateLog( TraceLogCategory ) ?? Log.Null;
            }
            catch {
                return Log.Null;
            }
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        private string GetContent( IHtmlContent render ) {
            var result = render?.ToString();
            if ( result == null )
                return null;
            return result.Replace( "{{", "{{{{" ).Replace( "}}", "}}}}" );
        }

        /// <summary>
        /// 是否忽略日志记录
        /// </summary>
        private bool IsIgnoreLog( string key ) {
            if ( _logs.ContainsKey( key ) == false )
                return false;
            var time = _logs[key];
            return DateTime.Now - time < TimeSpan.FromSeconds( 5 );
        }
    }
}
