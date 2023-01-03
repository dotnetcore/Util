using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.PageHeaders.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.PageHeaders {
    /// <summary>
    /// 页头底部,生成的标签为&lt;nz-page-header-footer&gt;&lt;/nz-page-header-footer&gt;
    /// </summary>
    [HtmlTargetElement( "util-page-header-footer" )]
    public class PageHeaderFooterTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new PageHeaderFooterRender( config );
        }
    }
}