using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Grid.Renders;

namespace Util.Ui.Zorro.Grid {
    /// <summary>
    /// 栅格布局 - 列
    /// </summary>
    [HtmlTargetElement( "util-column")]
    public class ColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzSpan,24栅格占位格数，可选值: 0 - 24, 为 0 时隐藏
        /// </summary>
        public int Span { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ColumnRender( new Config( context ) );
        }
    }
}