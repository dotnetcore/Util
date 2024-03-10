using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Modals.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Modals;

/// <summary>
/// 对话框内容容器,用于调整宽度,生成的标签为&lt;x-dialog-container>&lt;/x-dialog-container>
/// </summary>
[HtmlTargetElement( "util-dialog-container" )]
public class DialogContainerTagHelper : AngularTagHelperBase {
    /// <summary>
    /// minWidth,抽屉的最小宽度, 默认值: 600
    /// </summary>
    public double MinWidth { get; set; }
    /// <summary>
    /// [minWidth],抽屉的最小宽度, 默认值: 600
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
        return new DialogContainerRender( config );
    }
}