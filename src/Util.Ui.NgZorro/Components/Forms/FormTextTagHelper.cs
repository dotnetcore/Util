using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms {
    /// <summary>
    /// 表单文本,生成的标签为&lt;nz-form-text&gt;&lt;/nz-form-text&gt;
    /// </summary>
    [HtmlTargetElement( "util-form-text" )]
    public class FormTextTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new FormTextRender( config );
        }
    }
}