using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.TreeViews.Helpers;
using Util.Ui.NgZorro.Components.TreeViews.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.TreeViews;

/// <summary>
/// 树视图节点切换,生成的标签为&lt;nz-tree-node-toggle>&lt;/nz-tree-node-toggle>
/// </summary>
[HtmlTargetElement( "util-tree-node-toggle" )]
public class TreeNodeToggleTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzTreeNodeNoopToggle,不做任何操作的切换部分，可用于占位或者显示图标
    /// </summary>
    public string TreeNodeNoopToggle { get; set; }
    /// <summary>
    /// [nzTreeNodeToggleRecursive],是否递归展开/收起, 类型: boolean, 默认值: false
    /// </summary>
    public string Recursive { get; set; }
    /// <summary>
    /// 是否为图标添加 nzTreeNodeToggleRotateIcon 指令,定义切换部分中的图标，会随着展开收起状态自动旋转, 类型: boolean, 默认值: true
    /// </summary>
    public bool RotateIcon { get; set; }
    /// <summary>
    /// 是否为图标添加 nzTreeNodeToggleActiveIcon 指令,定义切换部分中的图标，使其具有激活状态的样式，可用于 loading 图标, 类型: boolean, 默认值: false
    /// </summary>
    public bool ActiveIcon { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new TreeNodeToggleService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new TreeNodeToggleRender( _config );
    }
}