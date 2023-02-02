using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 文字提示基类
    /// </summary>
    public abstract class TooltipTagHelperBase : AngularTagHelperBase {
        /// <summary>
        /// nzTooltipTitle,提示文字,支持i18n
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
        /// nzTooltipTrigger,文字提示触发行为,可选值: 'click' | 'focus' | 'hover' | null,为 null 时不响应光标事件,默认值: 'hover'
        /// </summary>
        public TooltipTrigger TooltipTrigger { get; set; }
        /// <summary>
        /// [nzTooltipTrigger],文字提示触发行为,可选值: 'click' | 'focus' | 'hover' | null,为 null 时不响应光标事件,默认值: 'hover'
        /// </summary>
        public string BindTooltipTrigger { get; set; }
        /// <summary>
        /// nzTooltipPlacement,提示框位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
        /// </summary>
        public TooltipPlacement TooltipPlacement { get; set; }
        /// <summary>
        /// [nzTooltipPlacement],提示框位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
        /// </summary>
        public string BindTooltipPlacement { get; set; }
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
        public bool TooltipVisible { get; set; }
        /// <summary>
        /// [nzTooltipVisible],提示框是否可见,默认值: false
        /// </summary>
        public string BindTooltipVisible { get; set; }
        /// <summary>
        /// nzTooltipMouseEnterDelay,鼠标移入后延时多久才显示提示框，单位：秒,默认值: 0.15
        /// </summary>
        public double TooltipMouseEnterDelay { get; set; }
        /// <summary>
        /// [nzTooltipMouseEnterDelay],鼠标移入后延时多久才显示提示框，单位：秒,默认值: 0.15
        /// </summary>
        public string BindTooltipMouseEnterDelay { get; set; }
        /// <summary>
        /// nzTooltipMouseLeaveDelay,鼠标移出后延时多久才隐藏提示框，单位：秒,默认值: 0.1
        /// </summary>
        public double TooltipMouseLeaveDelay { get; set; }
        /// <summary>
        /// [nzTooltipMouseLeaveDelay],鼠标移出后延时多久才隐藏提示框，单位：秒,默认值: 0.1
        /// </summary>
        public string BindTooltipMouseLeaveDelay { get; set; }
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
    }
}