using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.TreeViews.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.TreeViews; 

/// <summary>
/// 树节点可选项,定义树节点中的可选择部分,生成的标签为&lt;nz-tree-node-option>&lt;/nz-tree-node-option>
/// </summary>
[HtmlTargetElement( "util-tree-node-option" )]
public class TreeNodeOptionTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [nzSelected],是否选中,默认值: false
    /// </summary>
    public string Selected { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用,默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// (nzClick),单击事件,类型: EventEmitter&lt;MouseEvent>
    /// </summary>
    public string OnClick { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new TreeNodeOptionRender( config );
    }
}