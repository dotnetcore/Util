using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Tables.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables; 

/// <summary>
/// 表头单元格过滤器触发按钮,生成的标签为&lt;nz-filter-trigger>&lt;/nz-filter-trigger>
/// </summary>
[HtmlTargetElement( "util-filter-trigger" )]
public class FilterTriggerTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [nzDropdownMenu],下拉菜单组件,类型: NzDropdownMenuComponent
    /// </summary>
    public string DropdownMenu { get; set; }
    /// <summary>
    /// [nzVisible],是否显示下拉菜单
    /// </summary>
    public string Visible { get; set; }
    /// <summary>
    /// [(nzVisible)],是否显示下拉菜单
    /// </summary>
    public string BindonVisible { get; set; }
    /// <summary>
    /// [nzActive],是否激活选中图标效果,默认值: false
    /// </summary>
    public string Active { get; set; }
    /// <summary>
    /// [nzHasBackdrop],是否附带背景,默认值: false
    /// </summary>
    public string HasBackdrop { get; set; }
    /// <summary>
    /// (nzVisibleChange),下拉菜单显示状态变化事件,参数为 nzVisible,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnVisibleChange { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new FilterTriggerRender( config );
    }
}