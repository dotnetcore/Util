using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Icons.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Forms.TagHelpers {
    /// <summary>
    /// 下拉列表
    /// </summary>
    [HtmlTargetElement( "util-select" )]
    public class SelectTagHelper : TagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new IconRender( new Config() );
        }
    }
}
