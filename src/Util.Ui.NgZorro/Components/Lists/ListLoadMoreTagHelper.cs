using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists {
    /// <summary>
    /// 列表加载更多区域,生成的标签为&lt;nz-list-load-more>&lt;/nz-list-load-more>
    /// </summary>
    [HtmlTargetElement( "util-list-load-more" )]
    public class ListLoadMoreTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ListLoadMoreRender( config );
        }
    }
}