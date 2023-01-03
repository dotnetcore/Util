using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Breadcrumbs.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Breadcrumbs {
    /// <summary>
    /// 面包屑分隔符,生成的标签为&lt;nz-breadcrumb-separator&gt;&lt;/nz-breadcrumb-separator&gt;,放在&lt;util-breadcrumb&gt;&lt;/util-breadcrumb&gt;中使用
    /// </summary>
    [HtmlTargetElement( "util-breadcrumb-separator" )]
    public class BreadcrumbSeparatorTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new BreadcrumbSeparatorRender( config );
        }
    }
}