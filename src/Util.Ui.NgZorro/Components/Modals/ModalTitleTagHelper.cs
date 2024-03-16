using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Modals.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Modals;

/// <summary>
/// 对话框标题,生成的标签为&lt;div *nzModalTitle>&lt;/div>
/// </summary>
[HtmlTargetElement( "util-modal-title" )]
public class ModalTitleTagHelper : AngularTagHelperBase {
    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ModalTitleRender( config );
    }
}