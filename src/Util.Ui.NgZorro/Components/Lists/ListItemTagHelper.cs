using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists {
    /// <summary>
    /// 列表项,生成的标签为&lt;nz-list-item>&lt;/nz-list-item>
    /// </summary>
    [HtmlTargetElement( "util-list-item" )]
    public class ListItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzNoFlex],是否非 flex 布局渲染,默认值: false
        /// </summary>
        public bool NoFlex { get; set; }
        /// <summary>
        /// [nzNoFlex],是否非 flex 布局渲染,默认值: false
        /// </summary>
        public string BindNoFlex { get; set; }
        /// <summary>
        /// *cdkVirtualFor,虚拟滚动循环,范例: let item of items
        /// </summary>
        public string VirtualFor { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ListItemRender( config );
        }
    }
}