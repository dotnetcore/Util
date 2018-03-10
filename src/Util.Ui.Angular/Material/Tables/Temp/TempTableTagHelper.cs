using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Material.Tables.Configs;
using Util.Ui.Material.Tables.TagHelpers;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Tables.Temp {
    /// <summary>
    /// 表格
    /// </summary>
    [HtmlTargetElement( "util-table" )]
    public class TempTableTagHelper : TableTagHelper {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TempTableRender( new TableConfig( context ) );
        }
    }
}