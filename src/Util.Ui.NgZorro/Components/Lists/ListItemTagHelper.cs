using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Lists.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists; 

/// <summary>
/// 列表项,生成的标签为&lt;nz-list-item>&lt;/nz-list-item>
/// </summary>
[HtmlTargetElement( "util-list-item" )]
public class ListItemTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [nzActions],设置列表项操作,类型: Array&lt;TemplateRef&lt;void>>,默认值: []
    /// </summary>
    public string Actions { get; set; }
    /// <summary>
    /// nzContent,设置列表项内容,类型: string
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// [nzContent],设置列表项内容,类型: TemplateRef&lt;void>
    /// </summary>
    public string BindContent { get; set; }
    /// <summary>
    /// [nzExtra],设置列表项扩展,类型: TemplateRef&lt;void>
    /// </summary>
    public string Extra { get; set; }
    /// <summary>
    /// [nzNoFlex],是否非 flex 布局渲染,默认值: false
    /// </summary>
    public string NoFlex { get; set; }
    /// <summary>
    /// *cdkVirtualFor,虚拟滚动循环,范例: let item of items
    /// </summary>
    public string VirtualFor { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ListItemRender( config );
    }
}