using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Dropdowns.Helpers;
using Util.Ui.NgZorro.Components.Dropdowns.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Dropdowns; 

/// <summary>
/// 下拉菜单,生成的标签为&lt;nz-dropdown-menu&gt;&lt;ul nz-menu&gt;&lt;/ul&gt;&lt;/nz-dropdown-menu&gt;
/// </summary>
[HtmlTargetElement( "util-dropdown-menu" )]
public class DropdownMenuTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;

    /// <summary>
    /// [nzSelectable],是否允许选中，默认值：false,注意:该属性设置在&lt;ul nz-menu&gt;&lt;/ul&gt;上
    /// </summary>
    public string Selectable { get; set; }
    /// <summary>
    /// (nzClick),单击菜单项事件处理函数,注意:该属性设置在&lt;ul nz-menu&gt;&lt;/ul&gt;上
    /// </summary>
    public string OnClick { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new DropdownMenuService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new DropdownMenuRender( _config );
    }
}