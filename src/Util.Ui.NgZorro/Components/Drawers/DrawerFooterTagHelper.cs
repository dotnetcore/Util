using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Drawers.Renders;
using Util.Ui.NgZorro.Components.Flex;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Drawers;

/// <summary>
/// 抽屉页脚,生成的标签为&lt;div *xDrawerFooter>&lt;/div>
/// </summary>
[HtmlTargetElement( "util-drawer-footer" )]
public class DrawerFooterTagHelper : FlexTagHelper {
    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new DrawerFooterRender( config );
    }
}