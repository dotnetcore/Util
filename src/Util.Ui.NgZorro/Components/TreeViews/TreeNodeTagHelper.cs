using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TreeViews.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.TreeViews {
    /// <summary>
    /// 树节点,生成的标签为&lt;nz-tree-node>&lt;/nz-tree-node>
    /// </summary>
    [HtmlTargetElement( "util-tree-node" )]
    public class TreeNodeTagHelper : AngularTagHelperBase {
        /// <summary>
        /// *nzTreeNodeDef,树节点定义指令,范例: let node; when: hasChild
        /// </summary>
        public string TreeNodeDef { get; set; }
        /// <summary>
        /// nzTreeNodePadding,以添加内边距的方式显示节点缩进,性能最好
        /// </summary>
        public bool TreeNodePadding { get; set; }
        /// <summary>
        /// nzTreeNodeIndentLine,以添加缩进线的方式显示节点缩进
        /// </summary>
        public bool TreeNodeIndentLine { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TreeNodeRender( config );
        }
    }
}