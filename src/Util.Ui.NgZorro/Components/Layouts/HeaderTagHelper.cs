using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Layouts.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Layouts {
    /// <summary>
    /// 顶部布局,生成的标签为&lt;nz-header&gt;&lt;/nz-header&gt;,它的父容器为&lt;util-layout&gt;&lt;/util-layout&gt;,即&lt;nz-layout&gt;&lt;/nz-layout&gt;
    /// </summary>
    [HtmlTargetElement( "util-header" )]
    public class HeaderTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new HeaderRender( config );
        }
    }
}