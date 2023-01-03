using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Results.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Results {
    /// <summary>
    /// 结果操作区,生成的标签为&lt;div nz-result-extra>&lt;/div>
    /// </summary>
    [HtmlTargetElement( "util-result-extra" )]
    public class ResultExtraTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ResultExtraRender( config );
        }
    }
}