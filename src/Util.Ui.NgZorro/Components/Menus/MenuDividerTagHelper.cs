using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Renders;

namespace Util.Ui.NgZorro.Components.Menus {
    /// <summary>
    /// 菜单分隔线,生成的标签为&lt;li nz-menu-divider&gt;&lt;/li&gt;
    /// </summary>
    [HtmlTargetElement( "util-menu-divider" )]
    public class MenuDividerTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new MenuDividerRender( config );
        }
    }
}