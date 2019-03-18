using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Prime.Enums;
using Util.Ui.Prime.TreeTables.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Prime.TreeTables.TagHelpers {
    /// <summary>
    /// 树型表格列，该标签应放在 util-tree-table 中，
    /// 引用变量为 row,索引变量为 i,是否首行变量为 first,是否尾行变量为 last,
    /// 访问属性使用 row.data.属性名
    /// </summary>
    [HtmlTargetElement( "util-tree-table-column", ParentTag = "util-tree-table" )]
    public class ColumnTagHelper : AngularTagHelperBase {
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
        /// 表格列类型
        /// </summary>
        public TableColumnType Type { get; set; }
        /// <summary>
        /// 日期格式化字符串，格式说明：
        /// 1. 年 - yyyy
        /// 2. 月 - MM
        /// 3. 日 - dd
        /// 4. 时 - HH
        /// 5. 分 - mm
        /// 6. 秒 - ss
        /// 7. 毫秒 - SSS
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ColumnRender( new Config( context ) );
        }
    }
}