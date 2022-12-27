using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Renders;
using Util.Ui.Configs;

namespace Util.Ui.Angular.TagHelpers {
    /// <summary>
    /// 路由出口,生成的标签为&lt;router-outlet&gt;&lt;/router-outlet&gt;
    /// </summary>
    [HtmlTargetElement( "util-router-outlet" )]
    public class RouterOutletTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new RouterOutletRender( config );
        }
    }
}