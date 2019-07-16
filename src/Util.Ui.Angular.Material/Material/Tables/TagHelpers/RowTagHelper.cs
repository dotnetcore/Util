using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
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
        /// 表格标识
        /// </summary>
        private string _tableId;
        /// <summary>
        /// 显示列的集合，范例：['selectCheckbox','lineNumber', 'name','nickname','mobile']
        /// </summary>
        public string Columns { get; set; }
        /// <summary>
        /// 冻结表头，默认为true
        /// </summary>
        public bool StickyHeader { get; set; }
        /// <summary>
        /// 行单击事件，使用row访问行对象，范例：on-click="click(row)"
        /// </summary>
        public string OnClick { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RowRender( new Config( context ), _tableId );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">上下文</param>
        protected override void ProcessBefore( Context context ) {
            var shareConfig = context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
            if ( shareConfig == null )
                return;
            _tableId = shareConfig.TableId;
            shareConfig.AutoCreateRow = false;
        }
    }
}