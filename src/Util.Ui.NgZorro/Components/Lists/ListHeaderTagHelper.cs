using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists.Renders;

namespace Util.Ui.NgZorro.Components.Lists {
    /// <summary>
    /// 列表头部区域,生成的标签为&lt;nz-list-header>&lt;/nz-list-header>
    /// </summary>
    [HtmlTargetElement( "util-list-header" )]
    public class ListHeaderTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ListHeaderRender( config );
        }
    }
}