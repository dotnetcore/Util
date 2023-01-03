using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Layouts.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Layouts {
    /// <summary>
    /// 布局容器,生成的标签为&lt;nz-layout&gt;&lt;/nz-layout&gt;
    /// </summary>
    [HtmlTargetElement( "util-layout" )]
    public class LayoutTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new LayoutRender( config );
        }
    }
}