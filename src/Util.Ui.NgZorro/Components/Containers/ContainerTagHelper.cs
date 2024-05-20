using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Containers.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Containers; 

/// <summary>
/// 容器,生成的标签为&lt;ng-container>&lt;/ng-container>
/// </summary>
[HtmlTargetElement( "util-container" )]
public class ContainerTagHelper : AngularTagHelperBase {
    /// <summary>
    /// *ngTemplateOutlet,模板出口
    /// </summary>
    public string NgTemplateOutlet { get; set; }
    /// <summary>
    /// *nzMentionSuggestion,提及建议渲染模板
    /// </summary>
    public string MentionSuggestion { get; set; }
    /// <summary>
    /// *nzSpaceItem,值为 true 时设置为间距项,放入 &lt;util-space> 中使用
    /// </summary>
    public bool SpaceItem { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ContainerRender( config );
    }
}