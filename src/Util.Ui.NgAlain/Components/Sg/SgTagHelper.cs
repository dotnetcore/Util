using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sg.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Sg;

/// <summary>
/// ng-alain 简易栅格列组件,生成的标签为&lt;sg&gt;&lt;/sg&gt;
/// </summary>
[HtmlTargetElement( "util-column-x" )]
[HtmlTargetElement( "util-sg" )]
public class SgTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [col], 列跨度,占几列
    /// </summary>
    public string Span { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new SgRender( config );
    }
}