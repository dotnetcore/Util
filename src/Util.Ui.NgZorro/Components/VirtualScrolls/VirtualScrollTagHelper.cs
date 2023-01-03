using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.VirtualScrolls.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.VirtualScrolls {
    /// <summary>
    /// 虚拟滚动,生成的标签为&lt;ng-template nz-virtual-scroll>&lt;/ng-template>
    /// </summary>
    [HtmlTargetElement( "util-virtual-scroll" )]
    public class VirtualScrollTagHelper : AngularTagHelperBase {
        /// <summary>
        /// let-data,导出数据引用,使用变量 data 引用数据
        /// </summary>
        public string LetData { get; set; }
        /// <summary>
        /// let-index="index",导出索引引用,使用变量 index 引用索引
        /// </summary>
        public string LetIndex { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new VirtualScrollRender( config );
        }
    }
}