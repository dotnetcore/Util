using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists {
    /// <summary>
    /// 列表项元信息描述,生成的标签为&lt;nz-list-item-meta-description>&lt;/nz-list-item-meta-description>
    /// </summary>
    [HtmlTargetElement( "util-list-item-meta-description" )]
    public class ListItemMetaDescriptionTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ListItemMetaDescriptionRender( config );
        }
    }
}