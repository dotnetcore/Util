using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Grids.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Grids.TagHelpers {
    /// <summary>
    /// 栅格
    /// </summary>
    [HtmlTargetElement( "util-grid" )]
    public class GridTagHelper : TagHelperBase {
        /// <summary>
        /// 列数
        /// </summary>
        public int Columns { get; set; }
        /// <summary>
        /// 行高，可指定单位，如果仅传入数值，则单位为px
        /// </summary>
        public string RowHeight { get; set; }
        /// <summary>
        /// 单元格间距，可指定单位，如果仅传入数值，则单位为px
        /// </summary>
        public string GutterSize { get; set; }
        /// <summary>
        /// 合并列
        /// </summary>
        public int Colspan { get; set; }
        /// <summary>
        /// 左边占位合并列
        /// </summary>
        public int BeforeColspan { get; set; }
        /// <summary>
        /// 右边占位合并列
        /// </summary>
        public int AfterColspan { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new GridRender( new Config( context ) );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            context.Items[UiConst.Colspan] = context.AllAttributes[UiConst.Colspan];
            context.Items[UiConst.BeforeColspan] = context.AllAttributes[UiConst.BeforeColspan];
            context.Items[UiConst.AfterColspan] = context.AllAttributes[UiConst.AfterColspan];
        }
    }
}