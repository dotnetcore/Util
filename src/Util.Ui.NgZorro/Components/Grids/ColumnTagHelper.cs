using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Grids.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Grids {
    /// <summary>
    /// 栅格列,生成的标签为&lt;div nz-col&gt;&lt;/div&gt;
    /// </summary>
    [HtmlTargetElement( "util-column" )]
    public class ColumnTagHelper : ColumnTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ColumnRender( config );
        }
    }
}