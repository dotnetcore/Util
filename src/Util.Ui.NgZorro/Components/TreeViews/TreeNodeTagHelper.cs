using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.TreeViews.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.TreeViews;

/// <summary>
/// 树视图节点,生成的标签为&lt;nz-tree-node>&lt;/nz-tree-node>
/// </summary>
[HtmlTargetElement( "util-tree-node" )]
public class TreeNodeTagHelper : AngularTagHelperBase {
    /// <summary>
    /// *nzTreeNodeDef,树节点定义指令,范例: "let node; when: hasChild", `when` 用于定义是否使用此节点的方法，类型: `(index: number, nodeData: T) => boolean`, 优先匹配第一个返回 `true` 的节点。如果没有返回 `true` 的节点，则匹配未定义此方法的节点
    /// </summary>
    public string TreeNodeDef { get; set; }
    /// <summary>
    /// nzTreeNodePadding,以添加内边距的方式显示节点缩进,性能最好
    /// </summary>
    public string TreeNodePadding { get; set; }
    /// <summary>
    /// nzTreeNodeIndentLine,以添加缩进线的方式显示节点缩进
    /// </summary>
    public string TreeNodeIndentLine { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new TreeNodeRender( config );
    }
}