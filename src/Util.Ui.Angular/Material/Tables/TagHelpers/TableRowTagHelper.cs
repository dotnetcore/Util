using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Tables.TagHelpers {
    /// <summary>
    /// 表格行定义，该标签应放在 util-table 中
    /// </summary>
    [HtmlTargetElement( "util-table-row" )]
    public class TableRowTagHelper : TagHelperBase {
        /// <summary>
        /// 显示列的集合，范例：['selectCheckbox','lineNumber', 'name','nickname','mobile']
        /// </summary>
        public string Columns { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TableRowRender( new Config( context ) );
        }
    }
}