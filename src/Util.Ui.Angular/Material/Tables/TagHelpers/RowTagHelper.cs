using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Tables.Configs;
using Util.Ui.Material.Tables.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Tables.TagHelpers {
    /// <summary>
    /// 表格行定义，该标签应放在 util-table 中
    /// </summary>
    [HtmlTargetElement( "util-table-row", ParentTag = "util-table" )]
    public class RowTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 显示列的集合，范例：['selectCheckbox','lineNumber', 'name','nickname','mobile']
        /// </summary>
        public string Columns { get; set; }
        /// <summary>
        /// 冻结表头，默认为true
        /// </summary>
        public bool StickyHeader { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RowRender( new Config( context ) );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            var shareConfig = context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
            if( shareConfig != null )
                shareConfig.AutoCreateRow = false;
        }
    }
}