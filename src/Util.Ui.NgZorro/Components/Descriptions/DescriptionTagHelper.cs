using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Descriptions.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Descriptions; 

/// <summary>
/// 描述列表,生成的标签为&lt;nz-descriptions>&lt;/nz-descriptions>
/// </summary>
[HtmlTargetElement( "util-descriptions" )]
public class DescriptionTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzTitle,标题，显示在最顶部,类型: string|TemplateRef&lt;void>
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],标题，显示在最顶部,类型: string|TemplateRef&lt;void>
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// nzExtra,操作区域，显示在右上方,类型: string|TemplateRef&lt;void>
    /// </summary>
    public string Extra { get; set; }
    /// <summary>
    /// [nzExtra],操作区域，显示在右上方,类型: string|TemplateRef&lt;void>
    /// </summary>
    public string BindExtra { get; set; }
    /// <summary>
    /// [nzBordered],是否显示边框,默认值：false
    /// </summary>
    public string Bordered { get; set; }
    /// <summary>
    /// [nzColumn],一行包含的描述列表项数量,可以是数字,也可以写成响应式对象,类型: number|object,范例：{ xs: 8, sm: 16, md: 24},默认值: { xxl: 3, xl: 3, lg: 3, md: 3, sm: 2, xs: 1 }
    /// </summary>
    public string Column { get; set; }
    /// <summary>
    /// [nzColumn]={ xs: value },一行包含的描述列表项数量,&lt;576px超窄尺寸生效
    /// </summary>
    public int XsColumn { get; set; }
    /// <summary>
    /// [nzColumn]={ sm: value },一行包含的描述列表项数量,≥576px窄尺寸生效
    /// </summary>
    public int SmColumn { get; set; }
    /// <summary>
    /// [nzColumn]={ md: value },一行包含的描述列表项数量,≥768px中尺寸生效
    /// </summary>
    public int MdColumn { get; set; }
    /// <summary>
    /// [nzColumn]={ lg: value },一行包含的描述列表项数量,≥992px宽尺寸生效
    /// </summary>
    public int LgColumn { get; set; }
    /// <summary>
    /// [nzColumn]={ xl: value },一行包含的描述列表项数量,≥1200px超宽尺寸生效
    /// </summary>
    public int XlColumn { get; set; }
    /// <summary>
    /// [nzColumn]={ xxl: value },一行包含的描述列表项数量,≥1600px极宽尺寸生效
    /// </summary>
    public int XxlColumn { get; set; }
    /// <summary>
    /// nzSize,列表大小,只有设置 nzBordered 为 true 时生效,类型: 'default' | 'middle' | 'small',默认值: 'default'
    /// </summary>
    public DescriptionSize Size { get; set; }
    /// <summary>
    /// [nzSize],列表大小,只有设置 nzBordered 为 true 时生效,类型: 'default' | 'middle' | 'small',默认值: 'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzColon],是否显示冒号,默认值：true
    /// </summary>
    public string Colon { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new DescriptionRender( config );
    }
}