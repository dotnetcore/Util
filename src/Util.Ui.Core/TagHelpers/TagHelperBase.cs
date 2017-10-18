using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Renders;

namespace Util.Ui.TagHelpers {
    /// <summary>
    /// TagHelper
    /// </summary>
    public abstract class TagHelperBase : TagHelper {
        /// <summary>
        /// 渲染
        /// </summary>
        public override async void Process( TagHelperContext context, TagHelperOutput output ) {
            var content = await output.GetChildContentAsync();
            var render = GetRender( context, output, content );
            output.SuppressOutput();
            output.PostElement.SetHtmlContent( render );
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        /// <param name="content">组件内容</param>
        protected abstract IRender GetRender( TagHelperContext context, TagHelperOutput output, IHtmlContent content );
    }
}
