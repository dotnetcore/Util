using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Modals.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Modals;

/// <summary>
/// 对话框页脚,生成的标签为&lt;div *nzModalFooter>&lt;/div>
/// </summary>
[HtmlTargetElement( "util-modal-footer" )]
public class ModalFooterTagHelper : AngularTagHelperBase {
    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ModalFooterRender( config );
    }
}