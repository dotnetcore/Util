using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Ui.Components;
using Util.Ui.Renders;

namespace Util.Ui.TagHelpers {
    /// <summary>
    /// TagHelper
    /// </summary>
    public abstract class TagHelperBase : TagHelper {
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 渲染
        /// </summary>
        public override async void Process( TagHelperContext context, TagHelperOutput output ) {
            var content = await output.GetChildContentAsync();
            var render = GetRender( new Context( context, output, content ) );
            output.SuppressOutput();
            output.PostElement.SetHtmlContent( render );
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected abstract IRender GetRender( Context context );

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog( IRender render,string caption ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( caption )
                .Content( render.ToString() )
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog() {
            try {
                return Log.GetLog( ComponentBase.TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }
    }
}
