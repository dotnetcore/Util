using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Containers.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Containers; 

/// <summary>
/// 路由出口,生成的标签为&lt;router-outlet&gt;&lt;/router-outlet&gt;
/// </summary>
[HtmlTargetElement( "util-router-outlet" )]
public class RouterOutletTagHelper : AngularTagHelperBase {
    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new RouterOutletRender( config );
    }
}