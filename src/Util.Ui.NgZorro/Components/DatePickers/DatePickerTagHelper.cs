using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.DatePickers.Renders;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.DatePickers {
    /// <summary>
    /// 日期选择,生成的标签为&lt;nz-date-picker&gt;&lt;/nz-date-picker&gt;
    /// </summary>
    [HtmlTargetElement( "util-date-picker" )]
    public class DatePickerTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// nzId,组件内部 input 的 id 值
        /// </summary>
        public string InputId { get; set; }
        /// <summary>
        /// [nzAllowClear],是否允许清除内容
        /// </summary>
        public bool AllowClear { get; set; }
        /// <summary>
        /// [nzAllowClear],是否允许清除内容
        /// </summary>
        public string BindAllowClear { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦
        /// </summary>
        public bool AutoFocus { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦
        /// </summary>
        public string BindAutoFocus { get; set; }
        /// <summary>
        /// nzDefaultPickerValue,默认面板日期
        /// </summary>
        public string DefaultPickerValue { get; set; }
        /// <summary>
        /// [nzDefaultPickerValue],默认面板日期
        /// </summary>
        public string BindDefaultPickerValue { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzDisabledDate],不可选择日期函数,函数定义：(current: Date) => boolean
        /// </summary>
        public string DisabledDate { get; set; }
        /// <summary>
        /// [nzDisabledTime],不可选择时间函数,函数定义：(current: Date) => { nzDisabledHours, nzDisabledMinutes, nzDisabledSeconds },注意：该属性仅在 nzMode="date" 时有效
        /// </summary>
        public string DisabledTime { get; set; }
        /// <summary>
        /// nzDropdownClassName,弹出日历样式类名
        /// </summary>
        public string DropdownClassName { get; set; }
        /// <summary>
        /// [nzDropdownClassName],弹出日历样式类名
        /// </summary>
        public string BindDropdownClassName { get; set; }
        /// <summary>
        /// nzPopupStyle,弹出日历样式
        /// </summary>
        public string PopupStyle { get; set; }
        /// <summary>
        /// [nzPopupStyle],弹出日历样式
        /// </summary>
        public string BindPopupStyle { get; set; }
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
        /// [nzFormat],格式化字符串，格式说明：
        /// 1. 年 - yyyy
        /// 2. 月 - MM
        /// 3. 日 - dd
        /// 4. 时 - HH
        /// 5. 分 - mm
        /// 6. 秒 - ss
        /// 7. 毫秒 - SSS
        /// </summary>
        public string BindFormat { get; set; }
        /// <summary>
        /// [nzInputReadOnly],为 input 标签设置只读属性,避免在移动设备上触发小键盘
        /// </summary>
        public bool InputReadonly { get; set; }
        /// <summary>
        /// [nzInputReadOnly],为 input 标签设置只读属性,避免在移动设备上触发小键盘
        /// </summary>
        public string BindInputReadonly { get; set; }
        /// <summary>
        /// [nzLocale],国际化配置
        /// </summary>
        public string Locale { get; set; }
        /// <summary>
        /// nzMode,选择模式
        /// </summary>
        public DatePickerMode Mode { get; set; }
        /// <summary>
        /// [nzMode],选择模式
        /// </summary>
        public string BindMode { get; set; }
        /// <summary>
        /// nzPlaceHolder,输入框占位文本
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [nzPlaceHolder],输入框占位文本
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// nzRenderExtraFooter,添加额外页脚
        /// </summary>
        public string RenderExtraFooter { get; set; }
        /// <summary>
        /// [nzRenderExtraFooter],添加额外页脚
        /// </summary>
        public string BindRenderExtraFooter { get; set; }
        /// <summary>
        /// nzSize,输入框大小, 可选值: 'default' | 'small' |  'large'
        /// </summary>
        public InputSize Size { get; set; }
        /// <summary>
        /// [nzSize],输入框大小, 可选值: 'default' | 'small' |  'large'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// nzSuffixIcon,后缀图标
        /// </summary>
        public AntDesignIcon SuffixIcon { get; set; }
        /// <summary>
        /// [nzSuffixIcon],后缀图标
        /// </summary>
        public string BindSuffixIcon { get; set; }
        /// <summary>
        /// [nzBorderless],是否移除边框
        /// </summary>
        public bool Borderless { get; set; }
        /// <summary>
        /// [nzBorderless],是否移除边框
        /// </summary>
        public string BindBorderless { get; set; }
        /// <summary>
        /// [nzDateRender],自定义日期单元格内容,注意：该属性仅在 nzMode="date" 时有效
        /// </summary>
        public string DateRender { get; set; }
        /// <summary>
        /// [nzShowTime],是否显示时间选择,注意：该属性仅在 nzMode="date" 时有效
        /// </summary>
        public bool ShowTime { get; set; }
        /// <summary>
        /// [nzShowTime],是否显示时间选择,注意：该属性仅在 nzMode="date" 时有效
        /// </summary>
        public string BindShowTime { get; set; }
        /// <summary>
        /// [nzShowToday],是否显示“今天”按钮,注意：该属性仅在 nzMode="date" 时有效
        /// </summary>
        public bool ShowToday { get; set; }
        /// <summary>
        /// [nzShowToday],是否显示“今天”按钮,注意：该属性仅在 nzMode="date" 时有效
        /// </summary>
        public string BindShowToday { get; set; }
        /// <summary>
        /// [nzShowNow],是否显示“此刻”按钮,注意：该属性仅在 nzMode="date"，且 [nzShowTime]="true" 时有效
        /// </summary>
        public bool ShowNow { get; set; }
        /// <summary>
        /// [nzShowNow],是否显示“此刻”按钮,注意：该属性仅在 nzMode="date"，且 [nzShowTime]="true" 时有效
        /// </summary>
        public string BindShowNow { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// (nzOnOpenChange),弹出关闭日历事件
        /// </summary>
        public string OnOpenChange { get; set; }
        /// <summary>
        /// (nzOnOk),点击确定按钮事件
        /// </summary>
        public string OnOk { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new InputService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new DatePickerRender( _config );
        }
    }
}