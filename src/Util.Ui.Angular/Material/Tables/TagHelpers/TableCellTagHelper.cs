using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Tables.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Tables.TagHelpers {
    /// <summary>
    /// 表格单元格定义，该标签应放在 util-table-column 中，引用变量名为row，范例：{{row.name}}
    /// </summary>
    [HtmlTargetElement( "util-table-cell", ParentTag = "util-table-column" )]
    public class TableCellTagHelper : TagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TableCellRender( new Config( context ) );
        }
    }
}