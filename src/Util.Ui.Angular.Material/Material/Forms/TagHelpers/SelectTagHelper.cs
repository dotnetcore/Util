using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Forms.TagHelpers {
    /// <summary>
    /// 下拉列表
    /// </summary>
    [HtmlTargetElement( "util-select" )]
    public class SelectTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        public string DatasSource { get; set; }
        /// <summary>
        /// 启用重置项，重置项显示在列表的第一行，用于清空当前选择的值
        /// </summary>
        public bool EnableResetOption { get; set; }
        /// <summary>
        /// 重置项文本，重置项显示在列表的第一行，用于清空当前选择的值
        /// </summary>
        public string ResetOptionText { get; set; }
        /// <summary>
        /// 启用多选
        /// </summary>
        public bool Multiple { get; set; }
        /// <summary>
        /// 显示模板，值用{0}表示，范例：当前选中：{0} ,显示为 当前选中：1,2,3
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SelectRender( new SelectConfig( context ) );
        }
    }
}
