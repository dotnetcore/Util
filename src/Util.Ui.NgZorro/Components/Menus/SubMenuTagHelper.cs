using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Menus.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Menus; 

/// <summary>
/// 子菜单,生成的标签为&lt;li nz-submenu&gt;&lt;ul&gt;&lt;/ul&gt;&lt;/li&gt;
/// </summary>
[HtmlTargetElement( "util-submenu" )]
public class SubMenuTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzTitle,标题,支持多语言
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],标题
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// nzIcon,图标
    /// </summary>
    public AntDesignIcon Icon { get; set; }
    /// <summary>
    /// [nzIcon],图标
    /// </summary>
    public string BindIcon { get; set; }
    /// <summary>
    /// [nzOpen],是否展开, 默认值: false
    /// </summary>
    public string Open { get; set; }
    /// <summary>
    /// [(nzOpen)],是否展开, 默认值: false
    /// </summary>
    public string BindonOpen { get; set; }
    /// <summary>
    /// nzMenuClassName,自定义子菜单容器类名
    /// </summary>
    public string MenuClassName { get; set; }
    /// <summary>
    /// [nzMenuClassName],自定义子菜单容器类名
    /// </summary>
    public string BindMenuClassName { get; set; }
    /// <summary>
    /// nzPlacement,菜单弹出位置, 可选值: bottomLeft' | 'bottomCenter' | 'bottomRight' | 'topLeft' | 'topCenter' | 'topRight', 默认值: 'bottomLeft'
    /// </summary>
    public DropdownMenuPlacement Placement { get; set; }
    /// <summary>
    /// [nzPlacement],菜单弹出位置, 可选值: bottomLeft' | 'bottomCenter' | 'bottomRight' | 'topLeft' | 'topCenter' | 'topRight', 默认值: 'bottomLeft'
    /// </summary>
    public string BindPlacement { get; set; }
    /// <summary>
    /// [nzPaddingLeft],左内边距,单位: 像素, 类型: number
    /// </summary>
    public string PaddingLeft { get; set; }
    /// <summary>
    /// (nzOpenChange),展开状态变化事件, 类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnOpenChange { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new SubMenuRender( config );
    }
}