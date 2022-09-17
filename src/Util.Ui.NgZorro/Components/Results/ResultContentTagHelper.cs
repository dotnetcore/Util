using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Results.Renders;

namespace Util.Ui.NgZorro.Components.Results {
    /// <summary>
    /// 结果内容,生成的标签为&lt;div nz-result-content>&lt;/div>
    /// </summary>
    [HtmlTargetElement( "util-result-content" )]
    public class ResultContentTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ResultContentRender( config );
        }
    }
}