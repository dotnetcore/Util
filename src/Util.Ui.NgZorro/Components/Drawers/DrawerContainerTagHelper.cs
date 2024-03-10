using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Drawers.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Drawers;

/// <summary>
/// 抽屉内容容器,用于调整宽度,生成的标签为&lt;x-drawer-container>&lt;/x-drawer-container>
/// </summary>
[HtmlTargetElement( "util-drawer-container" )]
public class DrawerContainerTagHelper : AngularTagHelperBase {
    /// <summary>
    /// minWidth,抽屉的最小宽度, 默认值: 380
    /// </summary>
    public double MinWidth { get; set; }
    /// <summary>
    /// [minWidth],抽屉的最小宽度, 默认值: 380
    /// </summary>
    public string BindMinWidth { get; set; }
    /// <summary>
    /// maxWidth,抽屉的最大宽度
    /// </summary>
    public double MaxWidth { get; set; }
    /// <summary>
    /// [maxWidth],抽屉的最大宽度
    /// </summary>
    public string BindMaxWidth { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new DrawerContainerRender( config );
    }
}