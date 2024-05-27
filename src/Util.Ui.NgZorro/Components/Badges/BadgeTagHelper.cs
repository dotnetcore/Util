using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Badges.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Badges; 

/// <summary>
/// 徽标,生成的标签为&lt;nz-badge>&lt;/nz-badge>
/// </summary>
[HtmlTargetElement( "util-badge" )]
public class BadgeTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [nzStandalone],是否独立使用,类型: boolean
    /// </summary>
    public string Standalone { get; set; }
    /// <summary>
    /// nzColor,小圆点的颜色
    /// </summary>
    public AntDesignColor ColorType { get; set; }
    /// <summary>
    /// nzColor,小圆点的颜色
    /// </summary>
    public string Color { get; set; }
    /// <summary>
    /// [nzColor],小圆点的颜色
    /// </summary>
    public string BindColor { get; set; }
    /// <summary>
    /// [nzCount],显示数字，大于 `overflow-count` 时显示为 `99+`，为 0 时隐藏,类型: number | TemplateRef&lt;void>
    /// </summary>
    public string Count { get; set; }
    /// <summary>
    /// [nzDot],是否不显示数字，只显示一个小红点,类型: boolean, 默认值: false
    /// </summary>
    public string Dot { get; set; }
    /// <summary>
    /// [nzShowDot],是否显示小红点,类型: boolean, 默认值: true
    /// </summary>
    public string ShowDot { get; set; }
    /// <summary>
    /// [nzOverflowCount],封顶数字，类型: number,默认值: 99
    /// </summary>
    public string OverflowCount { get; set; }
    /// <summary>
    /// [nzShowZero],当数值为 0 时，是否显示徽标, 类型: boolean, 默认值: false
    /// </summary>
    public string ShowZero { get; set; }
    /// <summary>
    /// nzStatus,设置徽标为状态点,可选值: 'success' | 'processing' | 'default' | 'error' | 'warning'
    /// </summary>
    public BadgeStatus Status { get; set; }
    /// <summary>
    /// [nzStatus],设置徽标为状态点,可选值: 'success' | 'processing' | 'default' | 'error' | 'warning'
    /// </summary>
    public string BindStatus { get; set; }
    /// <summary>
    /// nzText,设置状态点的文本,支持多语言,仅在设置了 status 时有效
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// [nzText],设置状态点的文本,仅在设置了 status 时有效,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindText { get; set; }
    /// <summary>
    /// nzTitle,设置鼠标放在状态点上时显示的文字,为 null 时隐藏,类型: string | null,默认值: nzCount
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],设置鼠标放在状态点上时显示的文字,为 null 时隐藏,类型: string | null,默认值: nzCount
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// [nzOffset],设置状态点的位置偏移，格式为 [left, top]，表示状态点距默认位置左侧、上方的偏移量,类型: [number, number]
    /// </summary>
    public string Offset { get; set; }
    /// <summary>
    /// nzSize,设置徽标尺寸,仅在设置了 `count` 时有效, 可选值: default | small , 默认值: default
    /// </summary>
    public BadgeSize Size { get; set; }
    /// <summary>
    /// [nzSize],设置徽标尺寸,仅在设置了 `count` 时有效, 可选值: default | small , 默认值: default
    /// </summary>
    public string BindSize { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new BadgeRender( config );
    }
}