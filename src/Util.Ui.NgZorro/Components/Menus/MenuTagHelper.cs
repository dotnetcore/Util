using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Dropdowns.Helpers;
using Util.Ui.NgZorro.Components.Menus.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Menus; 

/// <summary>
/// 菜单,生成的标签为&lt;ul nz-menu&gt;&lt;/ul&gt;
/// </summary>
[HtmlTargetElement( "util-menu")]
public class MenuTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;

    /// <summary>
    /// nzMode,菜单模式,支持垂直、水平、和内嵌模式三种,可选值: 'vertical' | 'horizontal' | 'inline',默认值: 'vertical'
    /// </summary>
    public MenuMode Mode { get; set; }
    /// <summary>
    /// [nzMode],菜单模式,支持垂直、水平、和内嵌模式三种,可选值: 'vertical' | 'horizontal' | 'inline',默认值: 'vertical'
    /// </summary>
    public string BindMode { get; set; }
    /// <summary>
    /// [nzSelectable],是否允许选中，类型: boolean, 默认值：true
    /// </summary>
    public string Selectable { get; set; }
    /// <summary>
    /// nzTheme,主题颜色,可选值: 'light' | 'dark', 默认值: 'light'
    /// </summary>
    public MenuTheme Theme { get; set; }
    /// <summary>
    /// [nzTheme],主题颜色,可选值: 'light' | 'dark', 默认值: 'light'
    /// </summary>
    public string BindTheme { get; set; }
    /// <summary>
    /// [nzInlineCollapsed],菜单是否收起,内嵌模式 `nzMode='inline'` 有效, 类型: boolean
    /// </summary>
    public string InlineCollapsed { get; set; }
    /// <summary>
    /// [nzInlineIndent],菜单缩进宽度,内嵌模式 `nzMode='inline'` 有效, 类型: number, 默认值：24
    /// </summary>
    public string InlineIndent { get; set; }
    /// <summary>
    /// (nzClick),点击菜单项事件,类型: EventEmitter&lt;NzMenuItemDirective>
    /// </summary>
    public string OnClick { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new DropdownMenuService( _config );
        service.Init();
        service.AutoCreateUl( false );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new MenuRender( _config );
    }
}