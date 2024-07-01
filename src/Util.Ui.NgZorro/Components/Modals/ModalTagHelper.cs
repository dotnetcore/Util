using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Modals.Helpers;
using Util.Ui.NgZorro.Components.Modals.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Modals; 

/// <summary>
/// 对话框,生成的标签为&lt;nz-modal>&lt;/nz-modal>
/// </summary>
[HtmlTargetElement( "util-modal" )]
public class ModalTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzTitle,标题,支持多语言
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],标题,类型: string | TemplateRef
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// [nzMask],是否显示遮罩,类型: boolean, 默认值: true
    /// </summary>
    public string Mask { get; set; }
    /// <summary>
    /// [nzMaskClosable],点击遮罩是否允许关闭,类型: boolean, 默认值: true
    /// </summary>
    public string MaskClosable { get; set; }
    /// <summary>
    /// [nzCloseOnNavigation],当用户在历史中前进/后退时是否关闭对话框, 类型: boolean, 默认值: true
    /// </summary>
    public string CloseOnNavigation { get; set; }
    /// <summary>
    /// [(nzVisible)],是否可见,类型: boolean, 默认值: false
    /// </summary>
    public string Visible { get; set; }
    /// <summary>
    /// [nzClosable],是否显示关闭按钮,类型: boolean, 默认值: true
    /// </summary>
    public string Closable { get; set; }
    /// <summary>
    /// [nzDraggable],是否可拖动,类型: boolean, 默认值: false
    /// </summary>
    public string Draggable { get; set; }
    /// <summary>
    /// [nzOkLoading],确定按钮是否加载状态,类型: boolean, 默认值: false
    /// </summary>
    public string OkLoading { get; set; }
    /// <summary>
    /// [nzOkDisabled],是否禁用确定按钮,类型: boolean, 默认值: false
    /// </summary>
    public string OkDisabled { get; set; }
    /// <summary>
    /// [nzCancelLoading],取消按钮是否加载状态,类型: boolean, 默认值: false
    /// </summary>
    public string CancelLoading { get; set; }
    /// <summary>
    /// [nzCancelDisabled],是否禁用取消按钮,默认值: false
    /// </summary>
    public string CancelDisabled { get; set; }
    /// <summary>
    /// [nzKeyboard],按下ESC键是否允许关闭, 类型: boolean, 默认值: true
    /// </summary>
    public string Keyboard { get; set; }
    /// <summary>
    /// [nzCentered],是否垂直居中显示,类型: boolean, 默认值: false
    /// </summary>
    public string Centered { get; set; }
    /// <summary>
    /// [nzContent],内容,类型: string | TemplateRef | Component | ng-content
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// [nzComponentParams],组件参数,当 nzContent 为组件时作为实例属性，为 TemplateRef 时作为模版变量,类型: object
    /// </summary>
    public string ComponentParams { get; set; }
    /// <summary>
    /// [nzFooter],底部内容,1. 仅在普通模式下有效。2. 可通过传入 ModalButtonOptions 来最大程度自定义按钮。3. 当不需要底部时，可以设为 null。类型: string | TemplateRef | ModalButtonOptions,默认为确定取消按钮.
    /// </summary>
    public string Footer { get; set; }
    /// <summary>
    /// [nzZIndex],z-index,类型: number,默认值: 1000
    /// </summary>
    public string ZIndex { get; set; }
    /// <summary>
    /// [nzWidth],宽度, 使用数字时，默认单位为 px,类型: number | string, 默认值: 520
    /// </summary>
    public string Width { get; set; }
    /// <summary>
    /// nzWrapClassName,对话框外层容器样式类名
    /// </summary>
    public string WrapClassName { get; set; }
    /// <summary>
    /// [nzWrapClassName],对话框外层容器样式类名
    /// </summary>
    public string BindWrapClassName { get; set; }
    /// <summary>
    /// nzClassName,对话框样式类名
    /// </summary>
    public string ClassName { get; set; }
    /// <summary>
    /// [nzClassName],对话框样式类名
    /// </summary>
    public string BindClassName { get; set; }
    /// <summary>
    /// [nzStyle],浮层样式,类型: object
    /// </summary>
    public string NzStyle { get; set; }
    /// <summary>
    /// nzCloseIcon,关闭按钮图标,类型: string | TemplateRef&lt;void>,默认值: 'close'
    /// </summary>
    public AntDesignIcon CloseIcon { get; set; }
    /// <summary>
    /// [nzCloseIcon],关闭按钮图标,类型: string | TemplateRef&lt;void>,默认值: 'close'
    /// </summary>
    public string BindCloseIcon { get; set; }
    /// <summary>
    /// [nzMaskStyle],遮罩样式,类型: object
    /// </summary>
    public string MaskStyle { get; set; }
    /// <summary>
    /// [nzBodyStyle],主体样式,类型: object
    /// </summary>
    public string BodyStyle { get; set; }
    /// <summary>
    /// nzOkText,确认按钮文字,设为 null 表示不显示确认按钮,若在普通模式下使用了 nzFooter 参数，则该值无效,类型: string | null,默认值: '确定'
    /// </summary>
    public string OkText { get; set; }
    /// <summary>
    /// [nzOkText],确认按钮文字,设为 null 表示不显示确认按钮,若在普通模式下使用了 nzFooter 参数，则该值无效,类型: string | null,默认值: '确定'
    /// </summary>
    public string BindOkText { get; set; }
    /// <summary>
    /// nzCancelText,取消按钮文字,设为 null 表示不显示取消按钮,若在普通模式下使用了 nzFooter 参数，则该值无效,类型: string | null,默认值: '取消'
    /// </summary>
    public string CancelText { get; set; }
    /// <summary>
    /// [nzCancelText],取消按钮文字,设为 null 表示不显示取消按钮,若在普通模式下使用了 nzFooter 参数，则该值无效,类型: string | null,默认值: '取消'
    /// </summary>
    public string BindCancelText { get; set; }
    /// <summary>
    /// nzOkType,确认按钮类型,可选值: 'primary'|'dashed'|'link'|'text',默认值: 'primary'
    /// </summary>
    public ButtonType OkType { get; set; }
    /// <summary>
    /// [nzOkType],确认按钮类型,可选值: 'primary'|'dashed'|'link'|'text',默认值: 'primary'
    /// </summary>
    public string BindOkType { get; set; }
    /// <summary>
    /// [nzOkDanger],确认按钮是否危险按钮,类型: boolean, 默认值: false
    /// </summary>
    public string OkDanger { get; set; }
    /// <summary>
    /// nzIconType,图标类型,仅确认框模式下有效,默认值: 'question-circle'
    /// </summary>
    public AntDesignIcon IconType { get; set; }
    /// <summary>
    /// [nzIconType],图标类型,仅确认框模式下有效,默认值: 'question-circle'
    /// </summary>
    public string BindIconType { get; set; }
    /// <summary>
    /// nzAutofocus,自动聚焦及聚焦位置，为 null 时禁用,可选值: 'ok' | 'cancel' | 'auto' | null,默认值: 'auto'
    /// </summary>
    public ModalAutofocus Autofocus { get; set; }
    /// <summary>
    /// [nzAutofocus],自动聚焦及聚焦位置，为 null 时禁用,可选值: 'ok' | 'cancel' | 'auto' | null,默认值: 'auto'
    /// </summary>
    public string BindAutofocus { get; set; }
    /// <summary>
    /// (nzOnOk),确定事件,点击确定按钮时触发,类型: EventEmitter&lt;any>
    /// </summary>
    public string OnOk { get; set; }
    /// <summary>
    /// (nzOnCancel),取消事件,点击取消按钮时触发,类型: EventEmitter&lt;any>
    /// </summary>
    public string OnCancel { get; set; }
    /// <summary>
    /// (nzAfterOpen),打开后事件,打开对话框后触发, 类型: EventEmitter&lt;void>
    /// </summary>
    public string OnAfterOpen { get; set; }
    /// <summary>
    /// (nzAfterClose),关闭后事件,对话框完全关闭后触发,类型: EventEmitter&lt;any>
    /// </summary>
    public string OnAfterClose { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new ModalService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new ModalRender( _config );
    }
}