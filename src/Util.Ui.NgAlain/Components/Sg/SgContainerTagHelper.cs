using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sg.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Sg;

/// <summary>
/// ng-alain 简易栅格容器组件,生成的标签为&lt;div sg-container&gt;&lt;/div&gt;
/// </summary>
[HtmlTargetElement( "util-row-x" )]
[HtmlTargetElement( "util-sg-container" )]
public class SgContainerTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [gutter], 间距,默认值: 32
    /// </summary>
    public string Gutter { get; set; }
    /// <summary>
    /// [col], 一行显示几列,默认值: 2
    /// </summary>
    public string Column { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new SgContainerRender( config );
    }
}