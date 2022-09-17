using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 气泡确认框基类
    /// </summary>
    public abstract class PopconfirmTagHelperBase : AngularTagHelperBase {
        /// <summary>
        /// nzPopconfirmTitle,气泡确认框标题,类型: string | TemplateRef&lt;void>
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
        public bool PopconfirmVisible { get; set; }
        /// <summary>
        /// [nzPopconfirmVisible],气泡确认框是否可见,默认值: false
        /// </summary>
        public string BindPopconfirmVisible { get; set; }
        /// <summary>
        /// [nzPopconfirmShowArrow],气泡确认框是否显示箭头,默认值: true
        /// </summary>
        public bool PopconfirmShowArrow { get; set; }
        /// <summary>
        /// [nzPopconfirmShowArrow],气泡确认框是否显示箭头,默认值: true
        /// </summary>
        public string BindPopconfirmShowArrow { get; set; }
        /// <summary>
        /// nzPopconfirmMouseEnterDelay,鼠标移入后延时多久才显示气泡确认框，单位：秒,默认值: 0.15
        /// </summary>
        public double PopconfirmMouseEnterDelay { get; set; }
        /// <summary>
        /// [nzPopconfirmMouseEnterDelay],鼠标移入后延时多久才显示气泡确认框，单位：秒,默认值: 0.15
        /// </summary>
        public string BindPopconfirmMouseEnterDelay { get; set; }
        /// <summary>
        /// nzPopconfirmMouseLeaveDelay,鼠标移出后延时多久才隐藏气泡确认框，单位：秒,默认值: 0.1
        /// </summary>
        public double PopconfirmMouseLeaveDelay { get; set; }
        /// <summary>
        /// [nzPopconfirmMouseLeaveDelay],鼠标移出后延时多久才隐藏气泡确认框，单位：秒,默认值: 0.1
        /// </summary>
        public string BindPopconfirmMouseLeaveDelay { get; set; }
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
        public bool PopconfirmBackdrop { get; set; }
        /// <summary>
        /// [nzPopconfirmBackdrop],气泡确认框浮层是否应带背景,默认值: false
        /// </summary>
        public string BindPopconfirmBackdrop { get; set; }
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
        /// [nzCondition],气泡确认框条件触发,是否直接触发 nzOnConfirm 事件,而不弹出框,默认值: false
        /// </summary>
        public bool PopconfirmCondition { get; set; }
        /// <summary>
        /// [nzCondition],气泡确认框条件触发,是否直接触发 nzOnConfirm 事件,而不弹出框,默认值: false
        /// </summary>
        public string BindPopconfirmCondition { get; set; }
        /// <summary>
        /// nzIcon,气泡确认框自定义图标,类型: string | TemplateRef&lt;void>
        /// </summary>
        public AntDesignIcon PopconfirmIcon { get; set; }
        /// <summary>
        /// [nzIcon],气泡确认框自定义图标,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindPopconfirmIcon { get; set; }
        /// <summary>
        /// (nzPopconfirmVisibleChange),气泡确认框显示状态变化事件,类型: EventEmitter&lt;boolean>
        /// </summary>
        public string OnPopconfirmVisibleChange { get; set; }
        /// <summary>
        /// (nzOnCancel),取消事件,点击取消按钮时触发,类型: EventEmitter&lt;void>
        /// </summary>
        public string OnPopconfirmCancel { get; set; }
        /// <summary>
        /// (nzOnConfirm),确认事件,点击确认按钮时触发,类型: EventEmitter&lt;void>
        /// </summary>
        public string OnPopconfirmConfirm { get; set; }
    }
}