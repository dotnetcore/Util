using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Drawers.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Drawers;

/// <summary>
/// 抽屉内容,生成的标签为&lt;ng-container *nzDrawerContent>&lt;/ng-container>
/// </summary>
[HtmlTargetElement( "util-drawer-content" )]
public class DrawerContentTagHelper : AngularTagHelperBase {
    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new DrawerContentRender( config );
    }
}