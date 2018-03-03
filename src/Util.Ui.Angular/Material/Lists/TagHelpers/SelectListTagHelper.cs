using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 选择列表
    /// </summary>
    [HtmlTargetElement( "util-select-list" )]
    public class SelectListTagHelper : TagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SelectListRender( new Config( context ) );
        }
    }
}