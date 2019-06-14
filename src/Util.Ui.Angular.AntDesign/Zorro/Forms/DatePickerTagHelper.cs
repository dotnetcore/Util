using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Base;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 日期选择
    /// </summary>
    [HtmlTargetElement( "util-date-picker" )]
    public class DatePickerTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 日期选择器类型
        /// </summary>
        public DatePickerType Type { get; set; }
        /// <summary>
        /// nzFormat,格式化字符串，格式说明：
        /// 1. 年 - yyyy
        /// 2. 月 - MM
        /// 3. 日 - dd
        /// 4. 时 - HH
        /// 5. 分 - mm
        /// 6. 秒 - ss
        /// 7. 毫秒 - SSS
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// [nzShowTime],是否显示时间，默认值： false
        /// </summary>
        public bool ShowTime { get; set; }
        /// <summary>
        /// [nzShowToday],是否显示“今天”按钮，默认值： true
        /// </summary>
        public bool ShowToday { get; set; }
        /// <summary>
        /// [nzAllowClear],是否显示清除按钮，默认值： true
        /// </summary>
        public bool ShowClear { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动获取焦点，默认值： false
        /// </summary>
        public bool AutoFocus { get; set; }
        /// <summary>
        /// nzClassName,css类选择器
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// [nzDateRender],自定义日期单元格内容
        /// </summary>
        public string DateRender { get; set; }
        /// <summary>
        /// [nzDisabledDate],禁用日期函数
        /// </summary>
        public string DisabledDate { get; set; }
        /// <summary>
        /// 禁用今天之前的日期
        /// </summary>
        public bool DisabledBeforeToday { get; set; }
        /// <summary>
        /// 禁用明天之前的日期
        /// </summary>
        public bool DisabledBeforeTomorrow { get; set; }
        /// <summary>
        /// [nzLocale],国际化配置
        /// </summary>
        public string Locale { get; set; }
        /// <summary>
        /// (nzOnOpenChange),弹出和关闭日历事件
        /// </summary>
        public string OnOpenChange { get; set; }

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