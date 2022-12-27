using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists.Renders;

namespace Util.Ui.NgZorro.Components.Lists {
    /// <summary>
    /// 列表项扩展区域,生成的标签为&lt;nz-list-item-extra>&lt;/nz-list-item-extra>
    /// </summary>
    [HtmlTargetElement( "util-list-item-extra" )]
    public class ListItemExtraTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ListItemExtraRender( config );
        }
    }
}