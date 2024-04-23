using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.BackTops.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.BackTops;

/// <summary>
/// 回到顶部,生成的标签为&lt;nz-back-top&gt;&lt;/nz-back-top&gt;
/// </summary>
[HtmlTargetElement( "util-back-top" )]
public class BackTopTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [nzTemplate],自定义内容, 类型: TemplateRef&lt;void>
    /// </summary>
    public string Template { get; set; }
    /// <summary>
    /// [nzVisibilityHeight],滚动高度达到该值才显示回到顶部按钮, 默认值: 400
    /// </summary>
    public string VisibilityHeight { get; set; }
    /// <summary>
    /// [nzTarget],设置监听目标元素, 类型: string | Element, 默认值: window
    /// </summary>
    public string Target { get; set; }
    /// <summary>
    /// [nzDuration],回到顶部所需时间,单位: 毫秒, 默认值: 450
    /// </summary>
    public string Duration { get; set; }
    /// <summary>
    /// (nzClick), 单击回到顶部按钮事件,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnClick { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new BackTopRender( config );
    }
}