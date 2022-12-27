using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TreeViews.Renders;

namespace Util.Ui.NgZorro.Components.TreeViews {
    /// <summary>
    /// 树节点切换,生成的标签为&lt;nz-tree-node-toggle>&lt;/nz-tree-node-toggle>
    /// </summary>
    [HtmlTargetElement( "util-tree-node-toggle" )]
    public class TreeNodeToggleTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTreeNodeNoopToggle,不做任何操作的切换部分，可用于占位或者显示图标
        /// </summary>
        public bool TreeNodeNoopToggle { get; set; }

        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TreeNodeToggleRender( config );
        }
    }
}