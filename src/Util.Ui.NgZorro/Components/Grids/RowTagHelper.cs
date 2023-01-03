using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Grids.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Grids {
    /// <summary>
    /// 栅格行,生成的标签为&lt;div nz-row&gt;&lt;/div&gt;
    /// </summary>
    [HtmlTargetElement( "util-row")]
    public class RowTagHelper : RowTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new RowRender( config );
        }
    }
}