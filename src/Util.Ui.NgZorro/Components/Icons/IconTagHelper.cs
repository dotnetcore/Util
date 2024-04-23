using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Icons.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Icons; 

/// <summary>
/// 图标,生成的标签为&lt;i nz-icon&gt;&lt;/i&gt;
/// </summary>
[HtmlTargetElement( "util-icon" )]
public class IconTagHelper : TooltipTagHelperBase {
    /// <summary>
    /// nzType,图标类型
    /// </summary>
    public AntDesignIcon Type { get; set; }
    /// <summary>
    /// [nzType],图标类型
    /// </summary>
    public string BindType { get; set; }
    /// <summary>
    /// nzTheme,图标主题
    /// </summary>
    public IconTheme Theme { get; set; }
    /// <summary>
    /// [nzTheme],图标主题
    /// </summary>
    public string BindTheme { get; set; }
    /// <summary>
    /// [nzSpin],持续旋转
    /// </summary>
    public string Spin { get; set; }
    /// <summary>
    /// [nzRotate],旋转角度
    /// </summary>
    public string Rotate { get; set; }
    /// <summary>
    /// nzTwotoneColor,双色图标主题色,注意：仅适用双色图标主题
    /// </summary>
    public string TwotoneColor { get; set; }
    /// <summary>
    /// [nzTwotoneColor],双色图标主题色,注意：仅适用双色图标主题
    /// </summary>
    public string BindTwotoneColor { get; set; }
    /// <summary>
    /// nzIconfont,Iconfont图标
    /// </summary>
    public string IconFont { get; set; }
    /// <summary>
    /// [nzIconfont],Iconfont图标
    /// </summary>
    public string BindIconFont { get; set; }
    /// <summary>
    /// (click),单击事件处理函数
    /// </summary>
    public string OnClick { get; set; }
    /// <summary>
    /// nzPopoverTitle,气泡卡片标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string PopoverTitle { get; set; }
    /// <summary>
    /// [nzPopoverTitle],气泡卡片标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopoverTitle { get; set; }
    /// <summary>
    /// nzPopoverContent,气泡卡片内容,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string PopoverContent { get; set; }
    /// <summary>
    /// [nzPopoverContent],气泡卡片内容,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopoverContent { get; set; }
    /// <summary>
    /// nzPopoverTrigger,气泡卡片触发行为,为 null 时不响应光标事件,可选值: 'click' | 'focus' | 'hover' | null,默认值: 'hover'
    /// </summary>
    public PopoverTrigger PopoverTrigger { get; set; }
    /// <summary>
    /// [nzPopoverTrigger],气泡卡片触发行为,为 null 时不响应光标事件,可选值: 'click' | 'focus' | 'hover' | null,默认值: 'hover'
    /// </summary>
    public string BindPopoverTrigger { get; set; }
    /// <summary>
    /// nzPopoverPlacement,气泡卡片位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public PopoverPlacement PopoverPlacement { get; set; }
    /// <summary>
    /// [nzPopoverPlacement],气泡卡片位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public string BindPopoverPlacement { get; set; }
    /// <summary>
    /// nzPopoverOrigin,气泡卡片定位元素,类型: ElementRef
    /// </summary>
    public string PopoverOrigin { get; set; }
    /// <summary>
    /// [nzPopoverOrigin],气泡卡片定位元素,类型: ElementRef
    /// </summary>
    public string BindPopoverOrigin { get; set; }
    /// <summary>
    /// [nzPopoverVisible],气泡卡片是否可见,默认值: false
    /// </summary>
    public bool PopoverVisible { get; set; }
    /// <summary>
    /// [nzPopoverVisible],气泡卡片是否可见,默认值: false
    /// </summary>
    public string BindPopoverVisible { get; set; }
    /// <summary>
    /// [(nzPopoverVisible)],气泡卡片是否可见,默认值: false
    /// </summary>
    public string BindonPopoverVisible { get; set; }
    /// <summary>
    /// nzPopoverMouseEnterDelay,鼠标移入后延时多久才显示气泡卡片，单位：秒,默认值: 0.15
    /// </summary>
    public double PopoverMouseEnterDelay { get; set; }
    /// <summary>
    /// [nzPopoverMouseEnterDelay],鼠标移入后延时多久才显示气泡卡片，单位：秒,默认值: 0.15
    /// </summary>
    public string BindPopoverMouseEnterDelay { get; set; }
    /// <summary>
    /// nzPopoverMouseLeaveDelay,鼠标移出后延时多久才隐藏气泡卡片，单位：秒,默认值: 0.1
    /// </summary>
    public double PopoverMouseLeaveDelay { get; set; }
    /// <summary>
    /// [nzPopoverMouseLeaveDelay],鼠标移出后延时多久才隐藏气泡卡片，单位：秒,默认值: 0.1
    /// </summary>
    public string BindPopoverMouseLeaveDelay { get; set; }
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
    public bool PopoverBackdrop { get; set; }
    /// <summary>
    /// [nzPopoverBackdrop],气泡卡片浮层是否带背景,默认值: false
    /// </summary>
    public string BindPopoverBackdrop { get; set; }
    /// <summary>
    /// (nzPopoverVisibleChange),气泡卡片显示状态变化事件,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnPopoverVisibleChange { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new IconRender( config );
    }
}