using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists {
    /// <summary>
    /// 列表项元信息标题,生成的标签为&lt;nz-list-item-meta-title>&lt;/nz-list-item-meta-title>
    /// </summary>
    [HtmlTargetElement( "util-list-item-meta-title" )]
    public class ListItemMetaTitleTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ListItemMetaTitleRender( config );
        }
    }
}