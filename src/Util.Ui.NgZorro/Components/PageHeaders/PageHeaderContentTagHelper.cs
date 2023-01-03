using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.PageHeaders.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.PageHeaders {
    /// <summary>
    /// 页头内容,生成的标签为&lt;nz-page-header-content&gt;&lt;/nz-page-header-content&gt;
    /// </summary>
    [HtmlTargetElement( "util-page-header-content" )]
    public class PageHeaderContentTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new PageHeaderContentRender( config );
        }
    }
}