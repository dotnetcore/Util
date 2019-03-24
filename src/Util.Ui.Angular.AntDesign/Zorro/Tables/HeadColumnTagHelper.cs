using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Tables.Renders;

namespace Util.Ui.Zorro.Tables {
    /// <summary>
    /// 表格标题列定义，该标签应放在 util-table-head 中
    /// </summary>
    [HtmlTargetElement( "util-table-head-column",ParentTag = "util-table-head" )]
    public class HeadColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new HeadColumnRender( new Config( context ) );
        }
    }
}