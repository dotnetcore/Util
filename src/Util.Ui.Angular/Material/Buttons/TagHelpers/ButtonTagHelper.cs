using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Material.Buttons.Configs;
using Util.Ui.Material.Buttons.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Buttons.TagHelpers {
    /// <summary>
    /// 按钮TagHelper
    /// </summary>
    public class ButtonTagHelper : TagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        /// <param name="content">组件内容</param>
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, IHtmlContent content ) {
            return new ButtonRender( new ButtonConfig( context, output, content ) );
        }
    }
}
