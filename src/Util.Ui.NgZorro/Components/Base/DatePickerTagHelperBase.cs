using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Base;

/// <summary>
/// 日期选择基类
/// </summary>
public abstract class DatePickerTagHelperBase : FormControlTagHelperBase {
    /// <summary>
    /// nzId,组件内部 input 的 id 值
    /// </summary>
    public string NzId { get; set; }
    /// <summary>
    /// [nzId],组件内部 input 的 id 值
    /// </summary>
    public string BindNzId { get; set; }
    /// <summary>
    /// [nzAllowClear],是否允许清除内容, 类型: boolean, 默认值: true
    /// </summary>
    public string AllowClear { get; set; }
    /// <summary>
    /// [nzAutoFocus],是否自动聚焦, 类型: boolean, 默认值: false
    /// </summary>
    public string AutoFocus { get; set; }
    /// <summary>
    /// [nzBackdrop],浮层是否应带有背景板, 类型: boolean, 默认值: false
    /// </summary>
    public string Backdrop { get; set; }
    /// <summary>
    /// nzMode,选择模式,可选值: 'date' | 'week' | 'month' | 'year', 默认值: 'date'
    /// </summary>
    public DatePickerMode Mode { get; set; }
    /// <summary>
    /// [nzMode],选择模式,可选值: 'date' | 'week' | 'month' | 'year', 默认值: 'date'
    /// </summary>
    public string BindMode { get; set; }
    /// <summary>
    /// [nzShowTime],是否显示时间选择,注意：该属性仅在 nzMode="date" 时有效,可传入时间选择器配置参数, 类型: object | boolean
    /// </summary>
    public string ShowTime { get; set; }
    /// <summary>
    /// nzFormat,格式化字符串，格式说明：
    /// 1. 年 - yyyy
    /// 2. 月 - MM
    /// 3. 日 - dd
    /// 4. 时 - HH
    /// 5. 分 - mm
    /// 6. 秒 - ss
    /// 7. 毫秒 - SSS
    /// 8. 周 - ww
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
    /// 8. 周 - ww
    /// </summary>
    public string BindFormat { get; set; }
    /// <summary>
    /// nzSize,输入框尺寸, 可选值: 'default' | 'small' |  'large', 默认值: 'default'
    /// </summary>
    public InputSize Size { get; set; }
    /// <summary>
    /// [nzSize],输入框尺寸, 可选值: 'default' | 'small' |  'large', 默认值: 'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用, 类型: boolean, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// [nzBorderless],是否移除边框, 类型: boolean, 默认值: false
    /// </summary>
    public string Borderless { get; set; }
    /// <summary>
    /// [nzInline],是否内联模式, 类型: boolean, 默认值: false
    /// </summary>
    public string Inline { get; set; }
    /// <summary>
    /// [nzShowWeekNumber],是否在每一行显示周数, 类型: boolean, 默认值: false
    /// </summary>
    public string ShowWeekNumber { get; set; }
    /// <summary>
    /// [nzDisabledDate],不可选择日期函数,类型：(current: Date) => boolean
    /// </summary>
    public string DisabledDate { get; set; }
    /// <summary>
    /// nzPlaceHolder,输入框占位文本
    /// </summary>
    public string Placeholder { get; set; }
    /// <summary>
    /// [nzPlaceHolder],输入框占位文本
    /// </summary>
    public string BindPlaceholder { get; set; }
    /// <summary>
    /// nzRenderExtraFooter,添加额外页脚, 类型:  TemplateRef | string | (() => TemplateRef | string)
    /// </summary>
    public string RenderExtraFooter { get; set; }
    /// <summary>
    /// [nzRenderExtraFooter],添加额外页脚, 类型:  TemplateRef | string | (() => TemplateRef | string)
    /// </summary>
    public string BindRenderExtraFooter { get; set; }
    /// <summary>
    /// [nzDateRender],自定义日期单元格内容,注意：该属性仅在 nzMode="date" 时有效, 类型: string | TemplateRef&lt;Date> | ((d: Date) => TemplateRef&lt;Date> | string)
    /// </summary>
    public string DateRender { get; set; }
    /// <summary>
    /// nzStatus,校验状态, 可选值: 'error' | 'warning'
    /// </summary>
    public FormControlStatus Status { get; set; }
    /// <summary>
    /// [nzStatus],校验状态, 可选值: 'error' | 'warning'
    /// </summary>
    public string BindStatus { get; set; }
    /// <summary>
    /// nzPlacement,日期选择框弹出位置, 可选值: 'bottomLeft' | 'bottomRight' | 'topLeft' | 'topRight', 默认值: 'bottomLeft'
    /// </summary>
    public DatePickerPlacement Placement { get; set; }
    /// <summary>
    /// [nzPlacement],日期选择框弹出位置, 可选值: 'bottomLeft' | 'bottomRight' | 'topLeft' | 'topRight', 默认值: 'bottomLeft'
    /// </summary>
    public string BindPlacement { get; set; }
    /// <summary>
    /// nzDropdownClassName,弹出日历样式类名
    /// </summary>
    public string DropdownClassName { get; set; }
    /// <summary>
    /// [nzDropdownClassName],弹出日历样式类名
    /// </summary>
    public string BindDropdownClassName { get; set; }
    /// <summary>
    /// [nzPopupStyle],弹出日历样式, 类型: object
    /// </summary>
    public string PopupStyle { get; set; }
    /// <summary>
    /// [nzInputReadOnly],为 input 标签设置只读属性,避免在移动设备上触发小键盘, 类型: boolean, 默认值: false
    /// </summary>
    public string InputReadonly { get; set; }
    /// <summary>
    /// [nzLocale],国际化配置, 类型: object
    /// </summary>
    public string Locale { get; set; }
    /// <summary>
    /// nzSuffixIcon,后缀图标
    /// </summary>
    public AntDesignIcon SuffixIcon { get; set; }
    /// <summary>
    /// [nzSuffixIcon],后缀图标, 类型: string | TemplateRef
    /// </summary>
    public string BindSuffixIcon { get; set; }
    /// <summary>
    /// [required],是否必填项, 类型: boolean, 默认值: false
    /// </summary>
    public string Required { get; set; }
    /// <summary>
    /// 扩展属性 requiredMessage,必填项验证消息
    /// </summary>
    public string RequiredMessage { get; set; }
    /// <summary>
    /// 扩展属性 [requiredMessage],必填项验证消息
    /// </summary>
    public string BindRequiredMessage { get; set; }
    /// <summary>
    /// (nzOnOpenChange),弹出关闭日历事件, 类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnOpenChange { get; set; }
}