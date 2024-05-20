using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Timelines.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Timelines; 

/// <summary>
/// 时间轴,生成的标签为&lt;nz-timeline>&lt;/nz-timeline>
/// </summary>
[HtmlTargetElement( "util-timeline" )]
public class TimelineTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzPending,设置幽灵节点的内容,幽灵节点显示在最后
    /// </summary>
    public string Pending { get; set; }
    /// <summary>
    /// [nzPending],设置幽灵节点的内容,幽灵节点显示在最后,如果设置为 true 则显示默认幽灵节点,也可使用模板进行内容定制, 类型: string | boolean | TemplateRef&lt;void>,默认值: false
    /// </summary>
    public string BindPending { get; set; }
    /// <summary>
    /// nzPendingDot,设置幽灵节点时间轴点
    /// </summary>
    public string PendingDot { get; set; }
    /// <summary>
    /// [nzPendingDot],设置幽灵节点时间轴点,类型: string | TemplateRef&lt;void>,默认值: &lt;i nz-icon nzType="loading">&lt;/i>
    /// </summary>
    public string BindPendingDot { get; set; }
    /// <summary>
    /// [nzReverse],是否倒序排列,默认值: false
    /// </summary>
    public string Reverse { get; set; }
    /// <summary>
    /// nzMode,显示模式,可以改变时间轴和内容的相对位置,可选值: 'left' | 'alternate' | 'right' | 'custom'
    /// </summary>
    public TimelineMode Mode { get; set; }
    /// <summary>
    /// [nzMode],显示模式,可以改变时间轴和内容的相对位置,可选值: 'left' | 'alternate' | 'right' | 'custom'
    /// </summary>
    public string BindMode { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new TimelineRender( config );
    }
}