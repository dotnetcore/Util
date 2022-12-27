using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Renders;
using Util.Ui.Configs;

namespace Util.Ui.Angular.TagHelpers {
    /// <summary>
    /// 模板,生成的标签为&lt;ng-template&gt;&lt;/ng-template&gt;
    /// </summary>
    [HtmlTargetElement( "util-template" )]
    public class TemplateTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TemplateRender( config );
        }
    }
}