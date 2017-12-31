using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Buttons.Renders;
using Util.Ui.Material.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Buttons.TagHelpers {
    /// <summary>
    /// 按钮
    /// </summary>
    [HtmlTargetElement("util-button")]
    [HtmlTargetElement( "util-a" )]
    public class ButtonTagHelper : ButtonTagHelperBase {
        /// <summary>
        /// 颜色
        /// </summary>
        public Color AspColor { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ButtonRender( new Config( context.AllAttributes, context.OutputAttributes, context.Content ) );
        }
    }
}
