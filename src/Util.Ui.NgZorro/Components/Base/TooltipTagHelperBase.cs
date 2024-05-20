using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Base; 

/// <summary>
/// 文字提示基类
/// </summary>
public abstract class TooltipTagHelperBase : AngularTagHelperBase {
    /// <summary>
    /// nzTooltipTitle,提示文字,支持多语言
    /// </summary>
    public string TooltipTitle { get; set; }
    /// <summary>
    /// [nzTooltipTitle],提示文字,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindTooltipTitle { get; set; }
    /// <summary>
    /// 扩展属性,nzTooltipTitle是否显示update文本,默认文本为'Update',i18n文本为'util.update'
    /// </summary>
    public bool TooltipTitleUpdate { get; set; }
    /// <summary>
    /// 扩展属性,nzTooltipTitle是否显示delete文本,默认文本为'Delete',i18n文本为'util.delete'
    /// </summary>
    public bool TooltipTitleDelete { get; set; }
    /// <summary>
    /// 扩展属性,nzTooltipTitle是否显示detail文本,默认文本为'Detail',i18n文本为'util.detail'
    /// </summary>
    public bool TooltipTitleDetail { get; set; }
    /// <summary>
    /// nzTooltipPlacement,提示框位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public TooltipPlacement TooltipPlacement { get; set; }
    /// <summary>
    /// [nzTooltipPlacement],提示框位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public string BindTooltipPlacement { get; set; }
    /// <summary>
    /// [nzTooltipArrowPointAtCenter],箭头是否指向锚点的中心, 类型: boolean, 默认值: false
    /// </summary>
    public string TooltipArrowPointAtCenter { get; set; }
    /// <summary>
    /// [nzTooltipTitleContext],提示文字模板上下文, 类型: object, 范例: { $implicit: 'value' }
    /// </summary>
    public string TooltipTitleContext { get; set; }
    /// <summary>
    /// nzTooltipTrigger,文字提示触发行为,可选值: 'click' | 'focus' | 'hover' | null,为 null 时不响应光标事件,默认值: 'hover'
    /// </summary>
    public TooltipTrigger TooltipTrigger { get; set; }
    /// <summary>
    /// [nzTooltipTrigger],文字提示触发行为,可选值: 'click' | 'focus' | 'hover' | null,为 null 时不响应光标事件,默认值: 'hover'
    /// </summary>
    public string BindTooltipTrigger { get; set; }
    /// <summary>
    /// nzTooltipColor,扩展属性, 文字提示背景颜色
    /// </summary>
    public AntDesignColor TooltipColorType { get; set; }
    /// <summary>
    /// nzTooltipColor,文字提示背景颜色
    /// </summary>
    public string TooltipColor { get; set; }
    /// <summary>
    /// [nzTooltipColor],文字提示背景颜色
    /// </summary>
    public string BindTooltipColor { get; set; }
    /// <summary>
    /// [nzTooltipOrigin],文字提示定位元素,类型: ElementRef
    /// </summary>
    public string TooltipOrigin { get; set; }
    /// <summary>
    /// [nzTooltipVisible],提示框是否可见,默认值: false
    /// </summary>
    public string TooltipVisible { get; set; }
    /// <summary>
    /// [(nzTooltipVisible)],提示框是否可见,默认值: false
    /// </summary>
    public string BindonTooltipVisible { get; set; }
    /// <summary>
    /// [nzTooltipMouseEnterDelay],鼠标移入后延时多久才显示提示框，单位：秒,默认值: 0.15
    /// </summary>
    public string TooltipMouseEnterDelay { get; set; }
    /// <summary>
    /// [nzTooltipMouseLeaveDelay],鼠标移出后延时多久才隐藏提示框，单位：秒,默认值: 0.1
    /// </summary>
    public string TooltipMouseLeaveDelay { get; set; }
    /// <summary>
    /// nzTooltipOverlayClassName,提示框样式类名
    /// </summary>
    public string TooltipOverlayClassName { get; set; }
    /// <summary>
    /// [nzTooltipOverlayClassName],提示框样式类名
    /// </summary>
    public string BindTooltipOverlayClassName { get; set; }
    /// <summary>
    /// [nzTooltipOverlayStyle],提示框样式,类型: object
    /// </summary>
    public string TooltipOverlayStyle { get; set; }
    /// <summary>
    /// (nzTooltipVisibleChange),提示框显示状态变化事件,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnTooltipVisibleChange { get; set; }
    /// <summary>
    /// nzPopoverTitle,气泡卡片标题,支持多语言
    /// </summary>
    public string PopoverTitle { get; set; }
    /// <summary>
    /// [nzPopoverTitle],气泡卡片标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopoverTitle { get; set; }
    /// <summary>
    /// nzPopoverContent,气泡卡片内容
    /// </summary>
    public string PopoverContent { get; set; }
    /// <summary>
    /// [nzPopoverContent],气泡卡片内容,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopoverContent { get; set; }
    /// <summary>
    /// nzPopoverPlacement,气泡卡片位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public PopoverPlacement PopoverPlacement { get; set; }
    /// <summary>
    /// [nzPopoverPlacement],气泡卡片位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public string BindPopoverPlacement { get; set; }
    /// <summary>
    /// nzPopoverTrigger,气泡卡片触发行为,为 null 时不响应光标事件,可选值: 'click' | 'focus' | 'hover' | null,默认值: 'hover'
    /// </summary>
    public PopoverTrigger PopoverTrigger { get; set; }
    /// <summary>
    /// [nzPopoverTrigger],气泡卡片触发行为,为 null 时不响应光标事件,可选值: 'click' | 'focus' | 'hover' | null,默认值: 'hover'
    /// </summary>
    public string BindPopoverTrigger { get; set; }
    /// <summary>
    /// [nzPopoverVisible],气泡卡片是否可见,默认值: false
    /// </summary>
    public string PopoverVisible { get; set; }
    /// <summary>
    /// [(nzPopoverVisible)],气泡卡片是否可见,默认值: false
    /// </summary>
    public string BindonPopoverVisible { get; set; }
    /// <summary>
    /// [nzPopoverArrowPointAtCenter],箭头是否指向锚点的中心, 类型: boolean, 默认值: false
    /// </summary>
    public string PopoverArrowPointAtCenter { get; set; }
    /// <summary>
    /// [nzPopoverOrigin],气泡卡片定位元素,类型: ElementRef
    /// </summary>
    public string PopoverOrigin { get; set; }
    /// <summary>
    /// [nzPopoverMouseEnterDelay],鼠标移入后延时多久才显示气泡卡片，单位：秒,默认值: 0.15
    /// </summary>
    public string PopoverMouseEnterDelay { get; set; }
    /// <summary>
    /// [nzPopoverMouseLeaveDelay],鼠标移出后延时多久才隐藏气泡卡片，单位：秒,默认值: 0.1
    /// </summary>
    public string PopoverMouseLeaveDelay { get; set; }
    /// <summary>
    /// nzPopoverOverlayClassName,气泡卡片样式类名
    /// </summary>
    public string PopoverOverlayClassName { get; set; }
    /// <summary>
    /// [nzPopoverOverlayClassName],气泡卡片样式类名
    /// </summary>
    public string BindPopoverOverlayClassName { get; set; }
    /// <summary>
    /// [nzPopoverOverlayStyle],气泡卡片样式,类型: object
    /// </summary>
    public string PopoverOverlayStyle { get; set; }
    /// <summary>
    /// [nzPopoverBackdrop],气泡卡片浮层是否带背景,默认值: false
    /// </summary>
    public string PopoverBackdrop { get; set; }
    /// <summary>
    /// (nzPopoverVisibleChange),气泡卡片显示状态变化事件,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnPopoverVisibleChange { get; set; }
    /// <summary>
    /// nzPopconfirmTitle,气泡确认框标题,支持多语言
    /// </summary>
    public string PopconfirmTitle { get; set; }
    /// <summary>
    /// [nzPopconfirmTitle],气泡确认框标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopconfirmTitle { get; set; }
    /// <summary>
    /// nzPopconfirmTrigger,气泡确认框触发行为,可选值: 'click' | 'focus' | 'hover' | null,为 null 时不响应光标事件,默认值: 'hover'
    /// </summary>
    public PopconfirmTrigger PopconfirmTrigger { get; set; }
    /// <summary>
    /// [nzPopconfirmTrigger],气泡确认框触发行为,可选值: 'click' | 'focus' | 'hover' | null,为 null 时不响应光标事件,默认值: 'hover'
    /// </summary>
    public string BindPopconfirmTrigger { get; set; }
    /// <summary>
    /// nzPopconfirmPlacement,气泡确认框位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public PopconfirmPlacement PopconfirmPlacement { get; set; }
    /// <summary>
    /// [nzPopconfirmPlacement],气泡确认框位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public string BindPopconfirmPlacement { get; set; }
    /// <summary>
    /// [nzPopconfirmOrigin],气泡确认框定位元素,类型: ElementRef
    /// </summary>
    public string PopconfirmOrigin { get; set; }
    /// <summary>
    /// [nzPopconfirmVisible],气泡确认框是否可见,默认值: false
    /// </summary>
    public string PopconfirmVisible { get; set; }
    /// <summary>
    /// [(nzPopconfirmVisible)],气泡确认框是否可见,默认值: false
    /// </summary>
    public string BindonPopconfirmVisible { get; set; }
    /// <summary>
    /// [nzPopconfirmShowArrow],气泡确认框是否显示箭头,默认值: true
    /// </summary>
    public string PopconfirmShowArrow { get; set; }
    /// <summary>
    /// [nzPopconfirmArrowPointAtCenter],箭头是否指向锚点的中心,默认值: false
    /// </summary>
    public string PopconfirmArrowPointAtCenter { get; set; }
    /// <summary>
    /// [nzPopconfirmMouseEnterDelay],鼠标移入后延时多久才显示气泡确认框，单位：秒,默认值: 0.15
    /// </summary>
    public string PopconfirmMouseEnterDelay { get; set; }
    /// <summary>
    /// [nzPopconfirmMouseLeaveDelay],鼠标移出后延时多久才隐藏气泡确认框，单位：秒,默认值: 0.1
    /// </summary>
    public string PopconfirmMouseLeaveDelay { get; set; }
    /// <summary>
    /// nzPopconfirmOverlayClassName,气泡确认框样式类名
    /// </summary>
    public string PopconfirmOverlayClassName { get; set; }
    /// <summary>
    /// [nzPopconfirmOverlayClassName],气泡确认框样式类名
    /// </summary>
    public string BindPopconfirmOverlayClassName { get; set; }
    /// <summary>
    /// [nzPopconfirmOverlayStyle],气泡确认框样式,类型: object
    /// </summary>
    public string PopconfirmOverlayStyle { get; set; }
    /// <summary>
    /// [nzPopconfirmBackdrop],气泡确认框浮层是否应带背景,默认值: false
    /// </summary>
    public string PopconfirmBackdrop { get; set; }
    /// <summary>
    /// nzCancelText,气泡确认框取消按钮文字,默认值: '取消'
    /// </summary>
    public string PopconfirmCancelText { get; set; }
    /// <summary>
    /// [nzCancelText],气泡确认框取消按钮文字,默认值: '取消'
    /// </summary>
    public string BindPopconfirmCancelText { get; set; }
    /// <summary>
    /// nzOkText,气泡确认框确认按钮文字,默认值: '确定'
    /// </summary>
    public string PopconfirmOkText { get; set; }
    /// <summary>
    /// [nzOkText],气泡确认框确认按钮文字,默认值: '确定'
    /// </summary>
    public string BindPopconfirmOkText { get; set; }
    /// <summary>
    /// nzOkType,气泡确认框确认按钮类型,默认值: 'primary'
    /// </summary>
    public ButtonType PopconfirmOkType { get; set; }
    /// <summary>
    /// [nzOkType],气泡确认框确认按钮类型,默认值: 'primary'
    /// </summary>
    public string BindPopconfirmOkType { get; set; }
    /// <summary>
    /// [nzOkDanger],气泡确认框确认按钮是否为危险按钮,默认值: false
    /// </summary>
    public string PopconfirmOkDanger { get; set; }
    /// <summary>
    /// nzAutoFocus,气泡确认框按钮自动聚焦,类型: null | 'ok' | 'cancel',默认值: null
    /// </summary>
    public PopconfirmAutoFocus PopconfirmAutoFocus { get; set; }
    /// <summary>
    /// [nzAutoFocus],气泡确认框按钮自动聚焦,类型: null | 'ok' | 'cancel',默认值: null
    /// </summary>
    public string BindPopconfirmAutoFocus { get; set; }
    /// <summary>
    /// [nzCondition],是否直接触发 `on-popconfirm-confirm` 操作而不弹出气泡框,默认值: false
    /// </summary>
    public string PopconfirmCondition { get; set; }
    /// <summary>
    /// nzIcon,气泡确认框自定义图标,类型: string | TemplateRef&lt;void>
    /// </summary>
    public AntDesignIcon PopconfirmIcon { get; set; }
    /// <summary>
    /// [nzIcon],气泡确认框自定义图标,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopconfirmIcon { get; set; }
    /// <summary>
    /// [nzBeforeConfirm],确认前操作钩子，返回 false 中止执行 on-popconfirm-confirm 操作，支持异步,类型: (() => Observable&lt;boolean> | Promise&lt;boolean> | boolean) | null,默认值: null
    /// </summary>
    public string PopconfirmBeforeConfirm { get; set; }
    /// <summary>
    /// (nzPopconfirmVisibleChange),气泡确认框显示状态变化事件,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnPopconfirmVisibleChange { get; set; }
    /// <summary>
    /// (nzOnCancel),气泡确认框取消事件,点击取消按钮时触发,类型: EventEmitter&lt;void>
    /// </summary>
    public string OnPopconfirmCancel { get; set; }
    /// <summary>
    /// (nzOnConfirm),气泡确认框确认事件,点击确认按钮时触发,类型: EventEmitter&lt;void>
    /// </summary>
    public string OnPopconfirmConfirm { get; set; }
}