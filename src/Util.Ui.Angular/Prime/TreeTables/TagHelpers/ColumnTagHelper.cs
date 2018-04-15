using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Prime.TreeTables.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Prime.TreeTables.TagHelpers {
    /// <summary>
    /// 树型表格列，该标签应放在 util-tree-table 中
    /// </summary>
    [HtmlTargetElement( "util-tree-table-column", ParentTag = "util-tree-table" )]
    public class ColumnTagHelper : TagHelperBase {
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ColumnRender( new Config( context ) );
        }
    }
}