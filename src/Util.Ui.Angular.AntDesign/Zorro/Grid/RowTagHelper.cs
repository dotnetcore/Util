using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Grid.Renders;

namespace Util.Ui.Zorro.Grid {
    /// <summary>
    /// 栅格布局 - 行
    /// </summary>
    [HtmlTargetElement( "util-row")]
    public class RowTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RowRender( new Config( context ) );
        }
    }
}