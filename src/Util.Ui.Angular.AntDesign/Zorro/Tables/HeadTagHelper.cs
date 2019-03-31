using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Tables.Configs;
using Util.Ui.Zorro.Tables.Renders;

namespace Util.Ui.Zorro.Tables {
    /// <summary>
    /// 表格标题行定义，该标签应放在 util-table 中
    /// </summary>
    [HtmlTargetElement( "util-table-head", ParentTag = "util-table" )]
    public class HeadTagHelper : AngularTagHelperBase {
        /// <summary>
        /// (nzSortChange),排序变更事件,范例：on-sort-change="sort($event)"
        /// </summary>
        public string OnSortChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            var shareConfig = context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
            return new HeadRender( new Config( context ), shareConfig?.TableWrapperId, shareConfig?.IsSort );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            var shareConfig = context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
            if( shareConfig == null )
                return;
            shareConfig.AutoCreateHead = false;
        }
    }
}