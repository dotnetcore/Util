using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Carousels.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Carousels;

/// <summary>
/// 走马灯内容区域,生成的标签为&lt;div nz-carousel-content>&lt;/div>
/// </summary>
[HtmlTargetElement( "util-carousel-content" )]
public class CarouselContentTagHelper : AngularTagHelperBase {
    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new CarouselContentRender( config );
    }
}