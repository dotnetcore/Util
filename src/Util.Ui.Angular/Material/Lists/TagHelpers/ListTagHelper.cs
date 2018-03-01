using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 列表
    /// </summary>
    [HtmlTargetElement( "util-list" )]
    public class ListTagHelper : TagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ListRender( new Config( context ) );
        }
    }
}