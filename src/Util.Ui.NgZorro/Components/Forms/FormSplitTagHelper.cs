using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms {
    /// <summary>
    /// 表单分隔符,生成的标签为&lt;nz-form-split&gt;&lt;/nz-form-split&gt;
    /// </summary>
    [HtmlTargetElement( "util-form-split" )]
    public class FormSplitTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new FormSplitRender( config );
        }
    }
}