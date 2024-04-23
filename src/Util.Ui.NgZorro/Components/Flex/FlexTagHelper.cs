using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Flex.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Flex;

/// <summary>
/// 弹性布局栅格,生成的标签为&lt;div nz-flex>&lt;/div>
/// </summary>
[HtmlTargetElement( "util-flex" )]
public class FlexTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [nzVertical],是否垂直布局, 默认值: false
    /// </summary>
    public string Vertical { get; set; }
    /// <summary>
    /// nzJustify,对齐方式, 可选值: flex-start,center,flex-end,space-between,space-around,space-evenly
    /// </summary>
    public FlexJustify Justify { get; set; }
    /// <summary>
    /// [nzJustify],对齐方式, 可选值: flex-start,center,flex-end,space-between,space-around,space-evenly
    /// </summary>
    public string BindJustify { get; set; }
    /// <summary>
    /// nzAlign,垂直对齐方式, 可选值: flex-start,center,flex-end
    /// </summary>
    public FlexAlign Align { get; set; }
    /// <summary>
    /// [nzAlign],垂直对齐方式, 可选值: flex-start,center,flex-end
    /// </summary>
    public string BindAlign { get; set; }
    /// <summary>
    /// nzGap,元素之间的间距, 可选值: small,middle,large
    /// </summary>
    public FlexGap Gap { get; set; }
    /// <summary>
    /// [nzGap],元素之间的间距, 可选值: small,middle,large,自定义数值
    /// </summary>
    public string BindGap { get; set; }
    /// <summary>
    /// nzWrap,自动换行, 可选值: wrap,wrap-reverse,nowrap
    /// </summary>
    public FlexWrap Wrap { get; set; }
    /// <summary>
    /// [nzWrap],自动换行, 可选值: wrap,wrap-reverse,nowrap
    /// </summary>
    public string BindWrap { get; set; }
    /// <summary>
    /// nzFlex
    /// </summary>
    public string Flex { get; set; }
    /// <summary>
    /// [nzFlex]
    /// </summary>
    public string BindFlex { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new FlexRender( config );
    }
}