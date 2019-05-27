using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Forms.TagHelpers {
    /// <summary>
    /// 日期选择
    /// </summary>
    [HtmlTargetElement( "util-date-picker" )]
    public class DatePickerTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 是否显示清除按钮
        /// </summary>
        public bool ShowClearButton { get; set; }
        /// <summary>
        /// 只读
        /// </summary>
        public bool Readonly { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// 起始视图
        /// </summary>
        public DateView StartView { get; set; }
        /// <summary>
        /// 触摸模式
        /// </summary>
        public bool TouchUi { get; set; }
        /// <summary>
        /// 最小日期限制，范例：2000-1-1
        /// </summary>
        public string MinDate { get; set; }
        /// <summary>
        /// 最大日期限制，范例：2000-1-1
        /// </summary>
        public string MaxDate { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            var config = new TextBoxConfig( context ) { IsDatePicker = true };
            return new TextBoxRender( config );
        }
    }
}