using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Results.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Results {
    /// <summary>
    /// 结果副标题,生成的标签为&lt;div nz-result-subtitle>&lt;/div>
    /// </summary>
    [HtmlTargetElement( "util-result-subtitle" )]
    public class ResultSubtitleTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ResultSubtitleRender( config );
        }
    }
}