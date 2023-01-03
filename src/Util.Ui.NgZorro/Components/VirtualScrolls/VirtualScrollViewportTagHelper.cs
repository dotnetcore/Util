using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.VirtualScrolls.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.VirtualScrolls {
    /// <summary>
    /// 虚拟滚动窗口,生成的标签为&lt;cdk-virtual-scroll-viewport>&lt;/cdk-virtual-scroll-viewport>
    /// </summary>
    [HtmlTargetElement( "util-virtual-scroll-viewport" )]
    public class VirtualScrollViewportTagHelper : AngularTagHelperBase {
        /// <summary>
        /// itemSize,列的高度,单位:px,类型: number
        /// </summary>
        public double ItemSize { get; set; }
        /// <summary>
        /// [itemSize],列的高度,单位:px,类型: number
        /// </summary>
        public string BindItemSize { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new VirtualScrollViewportRender( config );
        }
    }
}